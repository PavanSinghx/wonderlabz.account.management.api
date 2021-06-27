using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wonderlabz.account.management.api.Enums;
using wonderlabz.account.management.api.Services.Rules.Transaction;

namespace wonderlabz.account.management.api.Factories
{
    public class TransactionRulesFactory : ITransactionRulesFactory
    {
        private readonly IConfiguration configuration;

        public TransactionRulesFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public TransactionFactorySummary GetRules(AccountType accountType)
        {
            var factorySummary = new TransactionFactorySummary
            {
                Rules = new List<ITransactionRule>(),
                AccountThresholdValue = 0m
            };

            switch (accountType)
            {
                case AccountType.Current:
                    factorySummary.AccountThresholdValue = decimal.Parse(this.configuration["AccountSettings:CurrentAccountMaximumOverdraftValue"]);
                    factorySummary.Rules.Add(new CurrentAccountTransactionRule());
                    break;
                case AccountType.Savings:
                    factorySummary.AccountThresholdValue = decimal.Parse(this.configuration["AccountSettings:SavingsAccountMinimumPrincipleValue"]);
                    factorySummary.Rules.Add(new SavingsAccountTransactionRule());
                    break;
                default:
                    break;
            }

            return factorySummary;
        }
    }
}
