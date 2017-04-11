using Evol.Common;
using System;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Employee : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string RealName { get; set; }

        public DateTime LastLoginTime { get; set; }

    }
}
