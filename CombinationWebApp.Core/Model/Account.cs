using CombinationWebApp.Core.Model.Abstraction;

namespace CombinationWebApp.Core.Model
{
    public class Account : EntityBase
    {
        public int AccountId { get; set; } = 0;
        public string AccountNumber { get; set; } = string.Empty;
        public decimal AccountBalance { get; set; } = 0;
        public int UserId { get; set; } = 0;
        public User? User { get; set; }

    }
}
