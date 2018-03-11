using Evol.Domain.Models;
using System;

namespace Sample.Domain.Models.AggregateRoots
{
    public class User : AggregateRoot<Guid>
    {
        public string Nick { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string AvatarPath { get; set; }

        public string Salt { get; set; }

        public int LoginCount { get; set; }

        public DateTime LastLoginTime { get; set; }
    }
}
