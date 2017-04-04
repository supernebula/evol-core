﻿using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.Repositories
{
    public class MovieRepository : BasicEntityFrameworkRepository<Movie, TMovieDbContext>, IMovieRepository
    {
        protected MovieRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
