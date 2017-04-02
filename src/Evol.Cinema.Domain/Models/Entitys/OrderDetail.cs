using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Cinema.Domain.Models.Entitys
{
    public class OrderDetail : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid ScreeningId { get; set; }
    }
}
