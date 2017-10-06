using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Models.Values;
using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Evol.Domain.Models;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Order : AggregateRoot
    {
        public string No { get; set; }
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public int ItemCount { get; set; }

        public double Amount { get; set; }

        public double PaidAmount { get; set; }

        public List<OrderDetail> Items{ get; set; }

        public OrderStatusType Status { get; set; }

        public DateTime? PayTime { get; set; }

        public DateTime? PaidTime { get; set; }

        public DateTime? ReceivedTime { get; set; }

        public DateTime? CompletedTime { get; set; }

        public DateTime? ClosedTime { get; set; }


    }
}
