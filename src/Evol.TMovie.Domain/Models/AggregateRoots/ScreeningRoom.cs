using System;
using System.Collections.Generic;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Models.Values;
using Evol.Common;

namespace Evol.TMovie.Domain.Models.AggregateRoots
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
