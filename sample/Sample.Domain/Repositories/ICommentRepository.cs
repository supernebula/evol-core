using Evol.Domain.Data;
using Sample.Domain.Models.Entities;
using System;

namespace Sample.Domain.Repositories
{
    public interface ICommentRepository : IRepository<Comment, Guid>
    {
    }
}
