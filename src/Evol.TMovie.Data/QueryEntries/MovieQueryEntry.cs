using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Repositories;
using Evol.Common;

namespace Evol.TMovie.Data.QueryEntries
{
    public class MovieQueryEntry : IMovieQueryEntry
    {
        public IMovieRepository MovieRepository { get; set; }

        public MovieQueryEntry(IMovieRepository movieRepos)
        {
            MovieRepository = movieRepos;
        }


        public async Task<Movie> FindAsync(Guid id)
        {
            return await MovieRepository.FindAsync(id);
        }

        public Task<List<Movie>> RetrieveAsync(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }


        public async Task<IPaged<Movie>> PagedAsync(int index, int size)
        {
            return await MovieRepository.PagedAsync(index, size);
        }


        public async Task<IPaged<Movie>> PagedAsync(Expression<Func<Movie, bool>> predicate, int pageIndex, int pageSize)
        {
            return await MovieRepository.PagedAsync(predicate, pageIndex, pageSize);
        }
    }
}
