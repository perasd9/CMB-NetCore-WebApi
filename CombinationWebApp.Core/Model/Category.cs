using CombinationWebApp.Core.Model.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationWebApp.Core.Model
{
    public class Category : EntityBase
    {
        public int CategoryId { get; set; } = 0;
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
        public IEnumerable<Transaction> Transactions { get; set; } = Enumerable.Empty<Transaction>();
    }
}
