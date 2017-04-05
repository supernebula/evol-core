using System;
using Evol.Common;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    /// <summary>
    /// 演员
    /// </summary>
    public class Actor : BaseEntity
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
}
