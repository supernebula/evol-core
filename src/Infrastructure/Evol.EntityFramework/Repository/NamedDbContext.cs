using Evol.Common;
using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFramework.Repository
{
    public abstract class NamedDbContext : DbContext, INamed
    {
        public string Name { get;set; }
    }
}
