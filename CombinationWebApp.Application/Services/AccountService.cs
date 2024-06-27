using CombinationWebApp.Application.Interfaces.Repositories.UnitOfWork;
namespace CombinationWebApp.Application.Services
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
