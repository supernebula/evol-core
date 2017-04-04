using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFramework
{
    public class NamedDbContext : DbContext, INamedDbContext
    {
        public string Name { get; set; }

        public NamedDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
