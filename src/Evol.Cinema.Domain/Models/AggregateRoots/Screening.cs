using System;
using Evol.TMovie.Domain.Models.Values;
using Evol.Common;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    /// <summary>
    /// 放映场次
    /// </summary>
    public class Screening : BaseEntity
    {
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
