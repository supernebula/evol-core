using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;

namespace Evol.TMovie.Data.QueryEntries
{
    public class SeatQueryEntry : BaseEntityFrameworkQuery<Seat, TMovieDbContext>, ISeatQueryEntry
    {

        public SeatQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<IPaged<Seat>> PagedAsync(SeatQueryParameter param, int pageIndex, int pageSize)
        {
            var result = await base.PagedAsync(e => e.ScreeningRoomId == param.ScreeningRoomId, pageIndex, pageSize);
            return result;
        }

        public async Task<List<Seat>> SelectAsync(SeatQueryParameter param)
        {
            var items = await base.SelectAsync(e => e.ScreeningRoomId == param.ScreeningRoomId);
            return items.ToList();
        }

        public async Task<List<Seat>> AllAsync(Guid screeningRoomId)
        {
            var items = await base.SelectAsync(e => e.ScreeningRoomId == screeningRoomId);
            return items.ToList();
        }

    }
}
