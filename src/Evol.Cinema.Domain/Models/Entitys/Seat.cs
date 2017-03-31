using System;
using Evol.Cinema.Domain.Models.Values;
using Evol.Common;

namespace Evol.Cinema.Domain.Models.Entitys
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
