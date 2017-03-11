using System.Data.Entity;
using Evol.Common;

namespace Evol.EntityFramework.Repository
{
    public abstract class NamedDbContext : DbContext, INamed
    {
        protected NamedDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public string Name { get;set; }
    }
}
