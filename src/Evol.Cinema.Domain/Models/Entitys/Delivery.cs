using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Cinema.Domain.Models.Entitys
{
    /// <summary>
    /// 交付
    /// </summary>
    public class Delivery : BaseEntity
    {
        public Guid OrderId { get; set; }

        public DeliveryMode Mode { get; set; }

        public string TakeCode { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }


}
    