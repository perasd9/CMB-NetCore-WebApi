using CombinationWebApp.Application.Interfaces.Repositories.UnitOfWork;

namespace CombinationWebApp.Application.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
