using Evol.Domain.Dto;
using System;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class OrderReceiveDto : IInputDto
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }
    }
}
