using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wonderlabz.account.management.api.Enums;

namespace wonderlabz.account.management.api.Models.Request
{
    public class OpenAccountRequest
    {
        public string FirstNames { get; set; }

        public string Surname { get; set; }

        public AccountType AccountType { get; set; }

        public decimal PrincipleAmount { get; set; }
    }
}
