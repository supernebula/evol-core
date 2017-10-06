using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class OrderCreateDto : IInputDto, ICanConfigMapTo<Order>
    {
        public string No { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public int ItemCount { get; set; }

        public float Amount { get; set; }

        public List<OrderDetail> Items { get; set; }

    }
}
