using Evol.EntityFrameworkCore.MySql.Repository;
using Sample.Domain.Models.Entities;
using Sample.Domain.Repositories;
using System;

namespace Sample.Storage.Repositories
{
    public class CommentRepository : BaseEntityFrameworkCoreRepository<Comment, Guid, EvolSampleDbContext>, ICommentRepository
    {
        public CommentRepository(IEfCoreUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
