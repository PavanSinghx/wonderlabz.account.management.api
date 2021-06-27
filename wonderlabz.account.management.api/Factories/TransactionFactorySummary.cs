using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wonderlabz.account.management.api.Services.Rules.Transaction;

namespace wonderlabz.account.management.api.Factories
{
    public class TransactionFactorySummary
    {
        public List<ITransactionRule> Rules { get; set; }

        public decimal AccountThresholdValue { get; set; }
    }
}
