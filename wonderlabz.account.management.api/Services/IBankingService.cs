using System.Threading.Tasks;
using wonderlabz.account.management.api.Models.Request;
using wonderlabz.account.management.api.Models.Response;

namespace wonderlabz.account.management.api.Services
{
    public interface IBankingService
    {
        Task<OpenAccountResponse> OpenUserAccount(OpenAccountRequest accountRequest);
        Task ExecuteTransaction(ExecuteTransactionRequest transactionRequest);
    }
}