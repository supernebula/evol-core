using Evol.EntityFrameworkCore.MySql.Repository;
using Sample.Domain.Models.AggregateRoots;
using Sample.Domain.Repositories;
using System;

namespace Sample.Storage.Repositories
{
    public class PostRepository : BaseEntityFrameworkCoreRepository<Post, Guid, EvolSampleDbContext>, IPostRepository
    {
        public PostRepository(IEfCoreUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
