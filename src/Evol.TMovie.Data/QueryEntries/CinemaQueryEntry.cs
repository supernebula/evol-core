using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Data.QueryEntries
{
    public class CinemaQueryEntry : ICinemaQueryEntry
    {
        public ICinemaRepository CinemaRepository { get; set; }

        public CinemaQueryEntry(ICinemaRepository cinemaRepo)
        {
            CinemaRepository = cinemaRepo;
        }


        public async Task<Cinema> FetchAsync(Guid id)
        {
            return await CinemaRepository.FindAsync(id);
        }

        public async Task<List<Cinema>> RetrieveAsync(CinemaQueryParameter param)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.Name))
                return new List<Cinema>();
            var items = await CinemaRepository.RetrieveAsync(e => e.Name.Contains(param.Name));
            return items.ToList();
        }


        public async Task<IPaged<Cinema>> PagedAsync(CinemaQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.Name))
                return await CinemaRepository.PagedAsync(pageIndex, pageSize);
            return await CinemaRepository.PagedAsync(e => e.Name.Contains(param.Name), pageIndex, pageSize);
        }
    }
}
