using CombinationWebApp.Core.Model.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationWebApp.Core.Model
{
    public class Transaction : EntityBase
    {
        public int TransactionId { get; set; } = 0;
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string AccountNumber { get; set; } = string.Empty;
        public string TransactionPurpose { get; set; } = string.Empty;
        public decimal TransactionAmount { get; set; } = 0;
        public string AccountRecipientNumber { get; set; } = string.Empty;
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;
        public int AccountId { get; set; } = 0;
        public Account? Account { get; set; }
        public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
    }
}
