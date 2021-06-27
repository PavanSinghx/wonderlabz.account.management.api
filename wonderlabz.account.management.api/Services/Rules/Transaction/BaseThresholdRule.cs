using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wonderlabz.account.management.api.Exceptions;
using wonderlabz.account.management.api.Models;
using wonderlabz.account.management.api.Models.Mappings;

namespace wonderlabz.account.management.api.Services.Rules.Transaction
{
    public abstract class BaseThresholdRule : ITransactionRule
    {
        public virtual void Execute(UserHistorySummary userHistorySummary)
        {
            decimal userSummary = this.GetRunningTotal(userHistorySummary.UserTransactionHistories);

            var accountValueAfterTransaction = userSummary + userHistorySummary.TransactionValue;

            if (accountValueAfterTransaction < userHistorySummary.MinimumAccountThreshold)
            {
                throw new InsufficientFundsException($"You cannot draw/deposit less that you current threshold of {userHistorySummary.MinimumAccountThreshold}.");
            }
        }

        private decimal GetRunningTotal(List<TbUserTransactionHistory> userTransactionHistories)
        {
            decimal userSummary = 0m;

            userTransactionHistories?.ForEach(u => userSummary += u.Amount);

            return userSummary;
        }
    }
}
