using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.Common;
using Evol.MongoDB.Repository;

namespace Evol.MongoDB.Test.Entities
{
    public class Order : BaseEntity, IEntity<string>
    {
        public string Receiver { get; set; }

        public string Address { get; set; }

        public decimal Amount { get; set; }

    }
}
