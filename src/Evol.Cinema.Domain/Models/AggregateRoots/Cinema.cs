using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Cinema : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
