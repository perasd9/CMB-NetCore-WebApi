using CombinationWebApp.Application.Interfaces.Repositories;
using CombinationWebApp.Core.Model;

namespace CombinationWebApp.Infrastructure.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ContextDb.Context context) : base(context)
        {
        }
    }
}
