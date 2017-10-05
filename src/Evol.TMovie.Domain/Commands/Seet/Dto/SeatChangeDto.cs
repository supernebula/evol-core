using System;
using Evol.TMovie.Domain.Commands.Seet.Dto;
using System.Collections.Generic;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class SeatChangeDto 
    {
        public List<SeatDto> Seats { get; set; }

        public Guid ScreeningRoomId { get; set; }

    }
}
