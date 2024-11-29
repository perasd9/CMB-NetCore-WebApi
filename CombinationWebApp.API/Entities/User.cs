﻿using CombinationWebApp.API.Entities.Abstraction;

namespace CombinationWebApp.API.Entities
{
    public class User : EntityBase
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }
    }
}