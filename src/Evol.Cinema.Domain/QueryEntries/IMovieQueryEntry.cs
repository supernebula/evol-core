using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Cinema.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;

namespace Evol.Cinema.Domain.QueryEntries
{
    public interface IMovieQueryEntry : IQueryEntry
    {
        Movie Fetch(Guid id);

        Task<Movie> FetchAsync(Guid id);

        List<Movie> Retrieve(MovieQueryParameter param);

        Task<List<Movie>> RetrieveAsync(MovieQueryParameter param);

        IPaged<Movie> Paged(int index, int size);

        Task<IPaged<Movie>> PagedAsync(int index, int size);

        IPaged<Movie> Paged(Expression<Func<Movie, bool>> predicate, int index, int size);

        Task<IPaged<Movie>> PagedAsync(Expression<Func<Movie, bool>> predicate,  int index, int size);
    }
}
