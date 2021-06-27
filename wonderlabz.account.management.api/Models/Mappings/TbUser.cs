using System;
using System.Collections.Generic;

namespace wonderlabz.account.management.api.Models.Mappings
{
    public partial class TbUser
    {
        public TbUser()
        {
            TbUserTransactionHistory = new HashSet<TbUserTransactionHistory>();
        }

        public int UserId { get; set; }
        public string Firstnames { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<TbUserTransactionHistory> TbUserTransactionHistory { get; set; }
    }
}
