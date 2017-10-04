using Evol.Common;
using Evol.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Cinema : AggregateRoot
    {
        /// <summary>
        /// 影院名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 影院地址
        /// </summary>
        public string Address { get; set; }
    }
}
