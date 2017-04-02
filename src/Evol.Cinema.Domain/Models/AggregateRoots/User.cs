using Evol.Common;

namespace Evol.Cinema.Domain.Models.AggregateRoots
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

    }
}
