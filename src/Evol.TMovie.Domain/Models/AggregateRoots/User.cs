using Evol.Common;
using Evol.Domain.Models;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class User : AggregateRoot
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

    }
}
