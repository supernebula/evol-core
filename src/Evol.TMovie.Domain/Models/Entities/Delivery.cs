using Evol.Common;
using Evol.TMovie.Domain.Models.Values;
using System;

namespace Evol.TMovie.Domain.Models.Entities
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
    