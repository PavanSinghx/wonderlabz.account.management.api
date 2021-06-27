using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wonderlabz.account.management.api.Exceptions;
using wonderlabz.account.management.api.Models;
using wonderlabz.account.management.api.Models.Mappings;

namespace wonderlabz.account.management.api.Services.Rules.Transaction
{
    public class SavingsAccountTransactionRule : BaseThresholdRule, ITransactionRule
    {
    }
}
