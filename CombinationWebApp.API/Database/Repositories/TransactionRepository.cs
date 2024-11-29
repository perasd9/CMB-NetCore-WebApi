using CombinationWebApp.API.Database.Context;
using CombinationWebApp.API.Database.Interfaces;
using CombinationWebApp.API.Entities;

namespace CombinationWebApp.API.Database.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
