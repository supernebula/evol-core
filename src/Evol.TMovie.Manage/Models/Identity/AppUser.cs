using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Models.Identity
{
    public class AppUser// : IdentityUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string RealName { get; set; }

        public string[] Roles { get; set; }

    }
}
