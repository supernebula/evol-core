using Evol.EntityFrameworkCore.MySql.Repository;
using Sample.Domain.Models.AggregateRoots;
using Sample.Domain.Repositories;

namespace Sample.Storage.Repositories
{
    public class PostRepository : BaseEntityFrameworkCoreRepository<Post, EvolSampleDbContext>, IPostRepository
    {
        public PostRepository(IEfCoreUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
