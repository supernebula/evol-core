using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Core.Identity
{
    public class HashUser
    {
        public string Username { get; set; }

        public string CleartextPassword { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }
    }
}
