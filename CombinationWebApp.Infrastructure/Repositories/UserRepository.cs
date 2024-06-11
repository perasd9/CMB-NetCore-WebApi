using CombinationWebApp.Application.Interfaces.Repositories;
using CombinationWebApp.Core.Model;

namespace CombinationWebApp.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ContextDb.Context context) : base(context)
        {
        }
    }
}
