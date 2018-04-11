using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;
using Evol.Common.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface ISeatQueryEntry : IQueryEntry
    {
        Task<Seat> FindAsync(Guid id);

        Task<List<Seat>> SelectAsync(SeatQueryParameter param);

        Task<IPaged<Seat>> PagedAsync(SeatQueryParameter param, int pageIndex, int pageSize);
    }
}
