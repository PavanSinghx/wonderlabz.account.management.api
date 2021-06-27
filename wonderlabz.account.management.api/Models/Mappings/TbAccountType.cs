using System;
using System.Collections.Generic;

namespace wonderlabz.account.management.api.Models.Mappings
{
    public partial class TbAccountType
    {
        public TbAccountType()
        {
            TbUserTransactionHistory = new HashSet<TbUserTransactionHistory>();
        }

        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }

        public virtual ICollection<TbUserTransactionHistory> TbUserTransactionHistory { get; set; }
    }
}
