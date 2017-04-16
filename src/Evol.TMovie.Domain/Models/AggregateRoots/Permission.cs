using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    /// <summary>
    /// Permission = Resource + Action
    /// </summary>
    public class Permission : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

    }
}
