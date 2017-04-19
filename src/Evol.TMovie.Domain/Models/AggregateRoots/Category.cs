using Evol.Common;
using Evol.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Category : AggregateRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}
