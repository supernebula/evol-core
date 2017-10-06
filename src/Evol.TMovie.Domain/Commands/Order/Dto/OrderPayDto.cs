using Evol.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class OrderPayDto : IInputDto
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public double PaidAmount { get; set; }
    }
}
