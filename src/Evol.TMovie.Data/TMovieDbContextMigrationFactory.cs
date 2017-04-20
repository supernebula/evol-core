using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Evol.TMovie.Data
{
    /// <summary>
    /// Only for use EntityFramework-Migration
    /// </summary>
    public class TMovieDbContextMigrationFactory : IDbContextFactory<TMovieDbContext>
    {
        public TMovieDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(options.ApplicationBasePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<TMovieDbContext>().UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new TMovieDbContext(dbOptionsBuilder.Options);
        }
    }
}
