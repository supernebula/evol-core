using System.Collections.Generic;

namespace Evol.EntityFramework.Repository
{
    public interface IEfActiveUnitOfWork
    {
        Dictionary<string, NamedDbContext> ActiveDbContexts { get; }

        void AddDbContext(string name, NamedDbContext dbContext);
        NamedDbContext GetDbContext(string name);
    }
}
