using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}
