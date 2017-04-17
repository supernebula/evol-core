using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IScreeningQueryEntry : IQueryEntry
    {

        Task<Screening> FindAsync(Guid id);

        Task<List<Screening>> RetrieveAsync(ScreeningQueryParameter param);

        Task<IPaged<Screening>> PagedAsync(ScreeningQueryParameter param, int pageIndex, int pageSize);
    }
}
