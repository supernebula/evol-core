using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Repositories;
using Evol.Common;

namespace Evol.TMovie.Data.QueryEntries
{
    public class MovieQueryEntry : IMovieQueryEntry
    {
        [Dependency]
        public IMovieRepository MovieRepository { get; set; }

        public Movie Fetch(Guid id)
        {
            return MovieRepository.Find(id);
        }

        public async Task<Movie> FetchAsync(Guid id)
        {
            return await MovieRepository.FindAsync(id);
        }

        public List<Movie> Retrieve(MovieQueryParameter param)
        {
            throw new NotImplementedException();

            //Func<Movie, bool> predicate = (m) => true;
            //if (!string.IsNullOrWhiteSpace(param.Name))
            //{
            //    var predicate1 = predicate;
            //    predicate = (m) => predicate1(m) && m.Name.Contains(param.Name);
            //}
            //if (param.Name != null)
            //{
            //    var predicate2 = predicate;
            //    predicate = (m) => predicate2(m) && m.Name.Contains(param.Name);
            //}
            //MovieRepository.Retrieve(predicate)
        }

        public Task<List<Movie>> RetrieveAsync(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<Movie> Paged(int index, int size)
        {
            return MovieRepository.Paged(index, size);
        }

        public async Task<IPaged<Movie>> PagedAsync(int index, int size)
        {
            return await MovieRepository.PagedAsync(index, size);
        }

        public IPaged<Movie> Paged(Expression<Func<Movie, bool>> predicate, int index, int size)
        {
            return MovieRepository.Paged(predicate, index, size);
        }

        public async Task<IPaged<Movie>> PagedAsync(Expression<Func<Movie, bool>> predicate, int pageIndex, int pageSize)
        {
            return await MovieRepository.PagedAsync(predicate, pageIndex, pageSize);
        }
    }
}
