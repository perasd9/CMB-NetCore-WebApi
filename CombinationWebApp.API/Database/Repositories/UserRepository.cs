using CombinationWebApp.API.Database.Context;
using CombinationWebApp.API.Database.Interfaces;
using CombinationWebApp.API.Entities;

namespace CombinationWebApp.API.Database.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
