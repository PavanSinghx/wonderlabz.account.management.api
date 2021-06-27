using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wonderlabz.account.management.api.Models.Request;
using wonderlabz.account.management.api.Models.Response;
using wonderlabz.account.management.api.Services;

namespace wonderlabz.account.management.api.Controllers
{
    [ApiController]
    [Route("v1/banking")]
    public class BankingController : ControllerBase
    {
        private readonly IBankingService bankingService;

        public BankingController(IBankingService bankingService)
        {
            this.bankingService = bankingService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<OpenAccountResponse> RegisterAccount([FromBody] OpenAccountRequest accountRequest)
        {
            return await this.bankingService.OpenUserAccount(accountRequest);
        }


        [HttpPost]
        [Route("track")]
        public async Task TrackTransaction([FromBody] ExecuteTransactionRequest transactionRequest)
        {
            await this.bankingService.ExecuteTransaction(transactionRequest);
        }
    }
}
