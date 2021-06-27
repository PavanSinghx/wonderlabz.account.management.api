using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wonderlabz.account.management.api.Enums;

namespace wonderlabz.account.management.api.Models.Request
{
    public class ExecuteTransactionRequest
    {
        public int UserId { get; set; }
        public decimal TransactionAmount { get; set; }
        public AccountType AccountType { get; set; }
    }
}
