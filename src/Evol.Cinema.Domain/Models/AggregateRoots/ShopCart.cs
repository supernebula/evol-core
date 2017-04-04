using Evol.Common;
using System;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class ShopCart : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public float Price { get; set; }

        public int Number { get; set; }

        public string ProductName { get; set; }
    }
}
