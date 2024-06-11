using CombinationWebApp.Core.Model.Abstraction;

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
