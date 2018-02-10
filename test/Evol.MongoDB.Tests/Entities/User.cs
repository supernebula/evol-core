using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.Common;
using Evol.MongoDB.Repository;
using Evol.Util;

namespace Evol.MongoDB.Test.Entities
{
    public class User : BaseEntity, IEntity<string>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public GenderType Gender { get; set; }

        public int Age { get; set; }
    }
}
