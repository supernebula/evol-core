using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid ScreeningId { get; set; }
    }
}
