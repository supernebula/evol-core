using Evol.Cinema.Domain.Models.Values;
using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Cinema.Domain.Models.AggregateRoots
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SupplierId { get; set; }

        /// <summary>
        /// 没件(包)数量
        /// </summary>
        public int QuantityPerUnit { get; set; }

        public float FixPrice { get; set; }

        public float SellPrice { get; set; }

        public string Stock { get; set; }

        public GoodsStateType GoodsState { get; set; }
    }
}
