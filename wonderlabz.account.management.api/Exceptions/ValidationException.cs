using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wonderlabz.account.management.api.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(string details) : base(details)
        {
        }
    }
}
