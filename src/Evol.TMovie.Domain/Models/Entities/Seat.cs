using System;
using Evol.TMovie.Domain.Models.Values;
using Evol.Common;

namespace Evol.TMovie.Domain.Models.Entities
{
    /// <summary>
    /// 座位
    /// </summary>
    public class Seat : BaseEntity
    {
        public SeatType SeatType { get; set; }

        public int RowNo { get; set; }

        public int ColumnNo { get; set; }

        public SeatStatusType Status { get; set; }

        public Guid ScreeningRoomId { get; set; }

    }


}
