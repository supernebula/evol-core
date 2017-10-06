using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Evol.TMovie.Domain.Models.Values;

namespace Evol.TMovie.Manage.Models
{
    public class SeatViewModel : IOutputDto, ICanConfigMapFrom<Seat>
    {
        public Guid Id { get; set; }

        public SeatType SeatType { get; set; }

        public int RowNo { get; set; }

        public int ColumnNo { get; set; }

        public SeatStatusType Status { get; set; }

        public Guid ScreeningRoomId { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Seat, SeatViewModel>();
        }
    }
}
