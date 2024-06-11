using CombinationWebApp.Protos;
using Grpc.Core;

namespace CombinationWebApp.Presentation.Grpc_Controllers
{
    public class AccountGrpcController : AccountService.AccountServiceBase
    {
        CombinationWebApp.Application.Services.AccountService _accountService;

        public AccountGrpcController(CombinationWebApp.Application.Services.AccountService accountService)
        {
            _accountService = accountService;
        }

        public override Task<AccountList> GetAll(Empty request, ServerCallContext context)
        {
            return base.GetAll(request, context);
        }

        public override Task<AccountList> GetBySearch(AccountSearchRequest request, ServerCallContext context)
        {
            return base.GetBySearch(request, context);
        }

        public override Task<AccountReply> Save(AccountRequest request, ServerCallContext context)
        {
            return base.Save(request, context);
        }

        public override Task<AccountReply> Update(AccountRequest request, ServerCallContext context)
        {
            return base.Update(request, context);
        }

        public override Task<Empty> Remove(AccountRemoveRequest request, ServerCallContext context)
        {
            return base.Remove(request, context);
        }
    }
}
