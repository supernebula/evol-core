using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;

namespace Evol.TMovie.Manage.Identity.Data
{
    //public class IdentityServiceDbContextFactory : IDesignTimeDbContextFactory<IdentityServiceDbContext>
    //{
    //    public IdentityServiceDbContext CreateDbContext(string[] args) =>
    //        Program.BuildWebHost(args).Services.GetRequiredService<IdentityServiceDbContext>();
    //}

    [Obsolete]
    public class IdentityServiceDbContextFactory
    {
        public IdentityServiceDbContext CreateDbContext(string[] args) =>
            Program.BuildWebHost(args).Services.GetRequiredService<IdentityServiceDbContext>();
    }
}
