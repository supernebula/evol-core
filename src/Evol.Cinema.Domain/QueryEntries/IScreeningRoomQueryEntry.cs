using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Cinema.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;

namespace Evol.Cinema.Domain.QueryEntries
{
    public interface IScreeningRoomQueryEntry : IQueryEntry
    {
        ScreeningRoom Fetch(Guid id);

        Task<ScreeningRoom> FetchAsync(Guid id);

        List<ScreeningRoom> Retrieve(ScreeningRoomQueryParameter param);

        Task<List<ScreeningRoom>> RetrieveAsync(ScreeningQueryParameter param);

        IPaged<ScreeningRoom> RetrievePaged(ScreeningQueryParameter param);

        Task<IPaged<ScreeningRoom>> RetrievePagedAsync(ScreeningQueryParameter param);
    }
}
