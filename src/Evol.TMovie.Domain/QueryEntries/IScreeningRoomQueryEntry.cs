using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;
using Evol.Common.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IScreeningRoomQueryEntry : IQueryEntry
    {

        Task<ScreeningRoom> FindAsync(Guid id);


        Task<List<ScreeningRoom>> SelectAsync(ScheduleQueryParameter param);


        Task<IPaged<ScreeningRoom>> PagedAsync(ScheduleQueryParameter param, int pageIndex, int pageSize);
    }
}
