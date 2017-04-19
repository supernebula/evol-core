using Evol.Common;
using Evol.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    /// <summary>
    /// Permission = Resource + Action
    /// </summary>
    public class Permission : AggregateRoot
    {
        public string Code { get; set; }

        public string Name { get; set; }

    }
}
