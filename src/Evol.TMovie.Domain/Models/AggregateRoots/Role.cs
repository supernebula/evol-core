﻿using Evol.Common;
using Evol.Domain.Models;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Role : AggregateRoot
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
