using System;
using System.Collections.Generic;

namespace wonderlabz.account.management.api.Models.Mappings
{
    public partial class TbUserTransactionHistory
    {
        public int UserTransactionHistoryId { get; set; }
        public int UserId { get; set; }
        public int AccountTypeId { get; set; }
        public decimal Amount { get; set; }

        public virtual TbAccountType AccountType { get; set; }
        public virtual TbUser User { get; set; }
    }
}
