using CombinationWebApp.Core.Model.Abstraction;
using ProtoBuf;

namespace CombinationWebApp.Core.Model
{
    [ProtoContract]
    public class User : EntityBase
    {
        [ProtoMember(1)]
        public int UserId { get; set; }

        [ProtoMember(2)]
        public string Username { get; set; }

        [ProtoMember(3)]
        public string Password { get; set; }

        [ProtoMember(4)]
        public string Name { get; set; }

        [ProtoMember(5)]
        public string Surname { get; set; }

        [ProtoMember(6)]
        public string Address { get; set; }
    }
}