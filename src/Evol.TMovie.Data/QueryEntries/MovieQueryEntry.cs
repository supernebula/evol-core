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
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class MovieQueryEntry : BaseEntityFrameworkQuery<Movie, TMovieDbContext>, IMovieQueryEntry
    {

        public MovieQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        //public override async Task<List<Movie>> SelectAsync(Guid[] ids)
        //{
        //    return await base.SelectAsync(ids);
        //}


        public Task<List<Movie>> SelectAsync(MovieQueryParameter param)
        {
            throw new NotImplementedException();
        } 

        public Task<IPaged<Movie>> PagedAsync(MovieQueryParameter param, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }


    }
}
