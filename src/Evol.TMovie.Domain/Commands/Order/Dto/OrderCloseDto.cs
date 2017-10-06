using Evol.Domain.Dto;
using System;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class OrderCloseDto : IInputDto
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }
    }
}
