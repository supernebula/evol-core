using System;
using System.Collections.Generic;
using Evol.Cinema.Domain.Models.Entities;
using Evol.Cinema.Domain.Models.Values;
using Evol.Common;

namespace Evol.Cinema.Domain.Models.AggregateRoots
{
    /// <summary>
    /// 放映厅
    /// </summary>
    public class ScreeningRoom : BaseEntity
    {
        public Guid CinemaId { get; set; }

        public string Name { get; set; }

        public SpaceDimensionType SpaceType { get; set; }

        public List<Seat> Seats { get; set; }

    }
}
