using Evol.TMovie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Evol.TMovie.ConsoleApp
{
    public class TMovieDbContextMigrationFactory : IDesignTimeDbContextFactory<TMovieDbContext>
    {
        public TMovieDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            var dbOptionsBuilder = (new DbContextOptionsBuilder<TMovieDbContext>()).UseSqlServer(configuration.GetConnectionString("TMConnection"));
            return new TMovieDbContext(dbOptionsBuilder.Options);
        }
    }
}
