using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.QueryEntries.Parameters
{
    public class SeatQueryParameter
    {

        public int RowNo { get; set; }

        public int ColumnNo { get; set; }


        public Guid ScreeningRoomId { get; set; }
    }
}
