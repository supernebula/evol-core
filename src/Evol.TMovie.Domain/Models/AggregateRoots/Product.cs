using Evol.TMovie.Domain.Models.Values;
using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Evol.Domain.Models;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Product : AggregateRoot
    {
        public string Title { get; set; }

        public string Brand { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SupplierId { get; set; }

        /// <summary>
        /// 每件(包)数量
        /// </summary>
        public int QuantityPerUnit { get; set; }

        public float FixPrice { get; set; }

        public float SellPrice { get; set; }

        public int Stock { get; set; }

        public GoodsStateType GoodsState { get; set; }
    }
}
