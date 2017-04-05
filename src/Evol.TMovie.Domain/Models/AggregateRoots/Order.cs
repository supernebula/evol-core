using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Models.Values;
using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Order : BaseEntity
    {
        public string No { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public int ItemCount { get; set; }

        public float Amount { get; set; }

        public List<OrderDetail> Items{ get; set; }

        public OrderStatusType Status { get; set; }

        public DateTime PayTime { get; set; }


    }
}
