﻿using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.Repositories
{
    public class ScreeningRepository : BasicEntityFrameworkRepository<Screening, TMovieDbContext>, IScreeningRepository
    {
        protected ScreeningRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
