using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Repositories
{
    public class CinemaRepository : BasicEntityFrameworkRepository<Cinema, TMovieDbContext>, ICinemaRepository
    {
        public CinemaRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
