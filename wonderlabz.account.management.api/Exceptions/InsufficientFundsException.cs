using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wonderlabz.account.management.api.Exceptions
{
    public class InsufficientFundsException : BaseException
    {
        public InsufficientFundsException(string details) : base(details)
        {
        }
    }
}
