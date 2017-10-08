using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class ScheduleQueryEntry : BaseEntityFrameworkQuery<Schedule, TMovieDbContext>, IScheduleQueryEntry
    {
        public ScheduleQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<List<Schedule>> SelectAsync(ScheduleQueryParameter param)
        {
            var items = await base.SelectAsync(e => e.CinemaId == param.CinemaId && e.Id == param.ScheduleId);
            return items.ToList();
        }


        public async Task<IPaged<Schedule>> PagedAsync(ScheduleQueryParameter param, int pageIndex, int pageSize)
        {
            var result = await base.PagedAsync(e => e.CinemaId == param.CinemaId, pageIndex, pageSize);
            return result;
        }

    }
}
