using CombinationWebApp.Application.Interfaces.Repositories;
using CombinationWebApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationWebApp.Infrastructure.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ContextDb.Context context) : base(context)
        {
        }
    }
}
