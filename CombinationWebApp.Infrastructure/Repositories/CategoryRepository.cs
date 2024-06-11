using CombinationWebApp.Application.Interfaces.Repositories;
using CombinationWebApp.Core.Model;

namespace CombinationWebApp.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ContextDb.Context context) : base(context)
        {
        }
    }
}
