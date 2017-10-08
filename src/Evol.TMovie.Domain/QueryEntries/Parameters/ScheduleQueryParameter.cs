using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries.Parameters
{
    public class ScheduleQueryParameter
    {
        public Guid CinemaId { get; set; }

        public Guid ScheduleId { get;set;}
    }
}
