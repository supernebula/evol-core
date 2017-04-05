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
        Screening Fetch(Guid id);

        Task<Screening> FetchAsync(Guid id);

        List<Screening> Retrieve(ScreeningQueryParameter param);

        Task<List<Screening>> RetrieveAsync(ScreeningQueryParameter param);

        IPaged<Screening> RetrievePaged(ScreeningQueryParameter param);

        Task<IPaged<Screening>> RetrievePagedAsync(ScreeningQueryParameter param);
    }
}
