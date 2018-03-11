using Evol.Domain.Data;
using Sample.Domain.Models.AggregateRoots;
using System;

namespace Sample.Domain.Repositories
{

    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
