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
    public class MovieQueryEntry : BaseEntityFrameworkQuery<Movie, TMovieDbContext>, IMovieQueryEntry
    {

        public MovieQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<List<Movie>> SelectAsync(MovieQueryParameter param)
        {
            var result = await SelectAsync(query => {
                if (!string.IsNullOrWhiteSpace(param.Name))
                    query = query.Where(e => e.Title.Contains(param.Name));
                if (param.ReleaseDate != null)
                    query = query.Where(e => e.ReleaseDate == (param.ReleaseDate.Value));
                if (!string.IsNullOrWhiteSpace(param.ReleaseRegion))
                    query = query.Where(e => e.ReleaseRegion.Contains(param.ReleaseRegion));
                if (param.SpaceType != null)
                    query = query.Where(e => e.SpaceType == param.SpaceType.Value);
                if (!string.IsNullOrWhiteSpace(param.Language))
                    query = query.Where(e => e.Language.Contains(param.Language));
                return query;
            });

            return result.ToList();
        } 

        public async Task<IPaged<Movie>> PagedAsync(MovieQueryParameter param, int pageIndex, int pageSize)
        {
            var result = await PagedAsync(query => {
                if (!string.IsNullOrWhiteSpace(param.Name))
                    query = query.Where(e => e.Title.Contains(param.Name));
                if (param.ReleaseDate != null)
                    query = query.Where(e => e.ReleaseDate == (param.ReleaseDate.Value));
                if (!string.IsNullOrWhiteSpace(param.ReleaseRegion))
                    query = query.Where(e => e.ReleaseRegion.Contains(param.ReleaseRegion));
                if (param.SpaceType != null)
                    query = query.Where(e => e.SpaceType == param.SpaceType.Value);
                if (!string.IsNullOrWhiteSpace(param.Language))
                    query = query.Where(e => e.Language.Contains(param.Language));
                return query;
            }, pageIndex, pageSize);

            return result;
        }
    }
}
