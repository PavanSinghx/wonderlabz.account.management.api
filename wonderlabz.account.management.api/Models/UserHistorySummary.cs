using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wonderlabz.account.management.api.Models.Mappings;

namespace wonderlabz.account.management.api.Models
{
    public class UserHistorySummary
    {
        public decimal MinimumAccountThreshold { get; set; }
        public decimal TransactionValue { get; set; }
        public List<TbUserTransactionHistory> UserTransactionHistories { get; set; }
    }
}
