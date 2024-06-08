using CombinationWebApp.Core.Model.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
