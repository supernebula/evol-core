using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFramework
{
    public abstract class NamedDbContext : DbContext, INamedDbContext
    {
        public string Name { get; set; }
    }
}
