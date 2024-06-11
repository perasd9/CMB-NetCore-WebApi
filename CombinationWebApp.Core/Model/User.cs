using CombinationWebApp.Core.Model.Abstraction;

namespace CombinationWebApp.Core.Model
{
    public class User : EntityBase
    {
        public int UserId { get; set; } = 0;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}