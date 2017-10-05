using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Models.Values;
using System;

namespace Evol.TMovie.Domain.Commands.Seet.Dto
{
    public class SeatDto : IInputDto, ICanConfigMapTo<Seat>
    {
        public SeatType SeatType { get; set; }

        public int RowNo { get; set; }

        public int ColumnNo { get; set; }

        public SeatStatusType Status { get; set; }

        public Guid ScreeningRoomId { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<SeatDto, Seat>();
        }
    }
}
