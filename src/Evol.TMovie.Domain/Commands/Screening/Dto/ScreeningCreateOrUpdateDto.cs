using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Commands.Dto
{
    class ScreeningCreateOrUpdateDto : IInputDto, ICanMapTo<Screening>
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }

        public Guid CinemaId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid ScreeningRoomId { get; set; }


        public double Price { get; set; }

        public double SellPrice { get; set; }


        public SpaceDimensionType SpaceType { get; set; }
    }
}
