using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Models.Values;
using System;


namespace Evol.TMovie.Domain.QueryEntries.Parameters
{
    public class OrderQueryParameter
    {
        public string No { get; set; }

        public Guid? UserId { get; set; }

        public string Title { get; set; }

        public int ItemCount { get; set; }

        public float? MinAmount { get; set; }

        public float? MaxAmount { get; set; }

        public OrderStatusType? Status { get; set; }

        public DateTime? StartPayTime { get; set; }

        public DateTime? EndPayTime { get; set; }
    }
}
