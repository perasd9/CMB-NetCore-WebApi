using CombinationWebApp.API.Database.Interfaces.UnitOfWork;

namespace CombinationWebApp.API.Features.Transactions
{
    public class TransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
