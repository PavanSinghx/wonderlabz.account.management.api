using System.Collections.Generic;
using wonderlabz.account.management.api.Models;
using wonderlabz.account.management.api.Models.Mappings;

namespace wonderlabz.account.management.api.Services.Rules.Transaction
{
    public interface ITransactionRule
    {
        void Execute(UserHistorySummary userHistorySummary);
    }
}