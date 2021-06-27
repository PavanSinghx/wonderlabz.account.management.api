using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wonderlabz.account.management.api.Exceptions
{
    public class InvalidPrincipleAmountException : BaseException
    {
        const string details = "You require over {0} to open an account. The principle value supplied was {1}";

        public InvalidPrincipleAmountException(decimal principleAmount, decimal amount)
            : base(string.Format(details, principleAmount, amount))
        { }
    }
}
