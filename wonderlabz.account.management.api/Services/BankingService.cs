using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wonderlabz.account.management.api.Enums;
using wonderlabz.account.management.api.Exceptions;
using wonderlabz.account.management.api.Factories;
using wonderlabz.account.management.api.Models;
using wonderlabz.account.management.api.Models.Mappings;
using wonderlabz.account.management.api.Models.Request;
using wonderlabz.account.management.api.Models.Response;
using wonderlabz.account.management.api.Repositories;

namespace wonderlabz.account.management.api.Services
{
    public class BankingService : IBankingService
    {
        private readonly IConfiguration configuration;
        private readonly IRepository<TbUser> userRepository;
        private readonly IRepository<TbUserTransactionHistory> userTransactionHistoryRepository;
        private readonly ITransactionRulesFactory transactionRulesFactory;

        public BankingService(IConfiguration configuration, IRepository<TbUser> userRepository, IRepository<TbUserTransactionHistory> userTransactionHistoryRepository,
                              ITransactionRulesFactory transactionRulesFactory)
        {
            this.configuration = configuration;
            this.userRepository = userRepository;
            this.userTransactionHistoryRepository = userTransactionHistoryRepository;
            this.transactionRulesFactory = transactionRulesFactory;
        }

        public async Task<OpenAccountResponse> OpenUserAccount(OpenAccountRequest accountRequest)
        {
            this.ValidateOpenAccountRequest(accountRequest);

            var user = new TbUser
            {
                Firstnames = accountRequest.FirstNames,
                Surname = accountRequest.Surname,
                TbUserTransactionHistory = new List<TbUserTransactionHistory> {
                    new TbUserTransactionHistory
                    {
                        Amount = accountRequest.PrincipleAmount,
                        AccountTypeId = (int)accountRequest.AccountType
                    }
                }
            };

            await this.userRepository.AddAsync(user);

            var userResponse = new OpenAccountResponse
            {
                UserId = user.UserId
            };

            return userResponse;
        }

        public async Task ExecuteTransaction(ExecuteTransactionRequest transactionRequest)
        {
            if (!Enum.IsDefined(typeof(AccountType), transactionRequest.AccountType))
            {
                throw new ValidationException("AccountType Invalid.");
            }

            var userTransactions = await this.userTransactionHistoryRepository.GetAllAsync(ut => ut.AccountTypeId == (int)transactionRequest.AccountType &&
                                                                                                 ut.UserId == transactionRequest.UserId);

            var transactionRuleSummary = this.transactionRulesFactory.GetRules(transactionRequest.AccountType);

            var userSummary = new UserHistorySummary
            {
                MinimumAccountThreshold = transactionRuleSummary.AccountThresholdValue,
                TransactionValue = transactionRequest.TransactionAmount,
                UserTransactionHistories = userTransactions
            };

            foreach (var rule in transactionRuleSummary.Rules)
            {
                rule.Execute(userSummary);
            }

            var transaction = new TbUserTransactionHistory
            {
                AccountTypeId = (int)transactionRequest.AccountType,
                UserId = transactionRequest.UserId,
                Amount = transactionRequest.TransactionAmount
            };

            await this.userTransactionHistoryRepository.AddAsync(transaction);
        }

        private void ValidateOpenAccountRequest(OpenAccountRequest accountRequest)
        {
            if (!Enum.IsDefined(typeof(AccountType), accountRequest.AccountType))
            {
                throw new ValidationException("AccountType Invalid.");
            }

            if (accountRequest.PrincipleAmount < 0)
            {
                throw new InvalidOperationException("An account must be opened with a principle value > 0.");
            }

            if (accountRequest.AccountType == AccountType.Savings)
            {
                var principleValue = decimal.Parse(this.configuration["AccountSettings:SavingsAccountMinimumPrincipleValue"]);

                if (accountRequest.PrincipleAmount < principleValue)
                {
                    throw new InvalidPrincipleAmountException(principleValue, accountRequest.PrincipleAmount);
                }
            }
        }
    }
}
