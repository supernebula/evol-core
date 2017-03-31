using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Cinema.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;

namespace Evol.Cinema.Domain.QueryEntries
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
