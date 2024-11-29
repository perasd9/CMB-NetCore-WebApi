using CombinationWebApp.API.Database.Context;
using CombinationWebApp.API.Database.Interfaces;
using CombinationWebApp.API.Entities;

namespace CombinationWebApp.API.Database.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
