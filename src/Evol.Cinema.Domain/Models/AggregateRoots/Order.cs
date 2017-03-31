using Evol.Cinema.Domain.Models.Entitys;
using Evol.Cinema.Domain.Models.Values;
using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Cinema.Domain.Models.AggregateRoots
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public int ItemCount { get; set; }

        public float Amount { get; set; }

        public List<OrderDetail> Items{ get; set; }

        public OrderStatusType Status { get; set; }
    }
}
