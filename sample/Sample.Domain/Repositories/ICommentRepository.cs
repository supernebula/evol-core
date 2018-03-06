using Evol.Domain.Data;
using Sample.Domain.Models.Entities;

namespace Sample.Domain.Repositories
{
    public interface ICommentRepository : IRepository<Comment, string>
    {
    }
}
