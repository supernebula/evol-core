using System;
using Evol.Common;
using Evol.Domain.Models;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    /// <summary>
    /// 演员
    /// </summary>
    public class Actor : AggregateRoot
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
}
