using CombinationWebApp.API.Database.Interfaces.UnitOfWork;

namespace CombinationWebApp.API.Features.Categories
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
