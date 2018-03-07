using Evol.EntityFrameworkCore.MySql.Repository;
using Sample.Domain.Models.Entities;
using Sample.Domain.Repositories;

namespace Sample.Storage.Repositories
{
    public class CommentRepository : BaseEntityFrameworkCoreRepository<Comment, string, EvolSampleDbContext>, ICommentRepository
    {
        public CommentRepository(IEfCoreUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
