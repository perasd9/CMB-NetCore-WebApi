using CombinationWebApp.Application.Interfaces.Repositories;
using CombinationWebApp.Core.Model;

namespace CombinationWebApp.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ContextDb.Context context) : base(context)
        {
        }
    }
}
