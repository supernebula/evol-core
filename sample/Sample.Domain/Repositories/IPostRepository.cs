using Evol.Domain.Data;
using Sample.Domain.Models.AggregateRoots;

namespace Sample.Domain.Repositories
{
    public interface IPostRepository : IRepository<Post, string>
    {
    }
}
