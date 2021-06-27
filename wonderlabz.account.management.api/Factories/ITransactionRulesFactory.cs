using System.Collections.Generic;
using wonderlabz.account.management.api.Enums;
using wonderlabz.account.management.api.Services.Rules.Transaction;

namespace wonderlabz.account.management.api.Factories
{
    public interface ITransactionRulesFactory
    {
        TransactionFactorySummary GetRules(AccountType accountType);
    }
}