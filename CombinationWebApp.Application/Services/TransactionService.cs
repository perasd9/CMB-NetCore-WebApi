using CombinationWebApp.Application.Interfaces.Repositories.UnitOfWork;

namespace CombinationWebApp.Application.Services
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
