using CombinationWebApp.Protos;
using Grpc.Core;

namespace CombinationWebApp.Presentation.Grpc_Controllers
{
    public class TransactionGrpcController : TransactionService.TransactionServiceBase
    {
        private readonly Application.Services.TransactionService _transactionService;

        public TransactionGrpcController(Application.Services.TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public override Task<TransactionList> GetAll(Empty request, ServerCallContext context)
        {
            return base.GetAll(request, context);
        }

        public override Task<TransactionList> GetBySearch(TransactionSearchRequest request, ServerCallContext context)
        {
            return base.GetBySearch(request, context);
        }

        public override Task<TransactionReply> Save(TransactionRequest request, ServerCallContext context)
        {
            return base.Save(request, context);
        }

        public override Task<TransactionReply> Update(TransactionRequest request, ServerCallContext context)
        {
            return base.Update(request, context);
        }

        public override Task<Empty> Remove(TransactionRemoveRequest request, ServerCallContext context)
        {
            return base.Remove(request, context);
        }
    }
}
