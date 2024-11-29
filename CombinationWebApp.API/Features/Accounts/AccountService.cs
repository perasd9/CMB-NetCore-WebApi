using CombinationWebApp.API.Database.Interfaces.UnitOfWork;

namespace CombinationWebApp.API.Features.Accounts
{
    public class AccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
