using Evol.Common;
using Evol.Domain.Models;
using System;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class ShopCart : AggregateRoot
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public float Price { get; set; }

        public int Number { get; set; }

        public string ProductName { get; set; }
    }
}
