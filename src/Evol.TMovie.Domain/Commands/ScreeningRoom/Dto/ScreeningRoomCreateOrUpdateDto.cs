using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Models.Values;
using System;
using System.Collections.Generic;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class ScreeningRoomCreateOrUpdateDto : IInputDto, ICanMapTo<ScreeningRoom>
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }

        public string Title { get; set; }

        public SpaceDimensionType SpaceType { get; set; }

        public List<Seat> Seats { get; set; }
    }
}
