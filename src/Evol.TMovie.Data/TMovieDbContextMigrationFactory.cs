//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace Evol.TMovie.Data
//{
//    //.net core 1.1
//    ///// <summary>
//    ///// Only for use EntityFramework-Migration
//    ///// </summary>
//    //public class TMovieDbContextMigrationFactory : IDbContextFactory<TMovieDbContext>
//    //{
//    //    public TMovieDbContext Create(DbContextFactoryOptions options)
//    //    {
//    //        var builder = new ConfigurationBuilder()
//    //            .SetBasePath(options.ApplicationBasePath)
//    //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//    //        var configuration = builder.Build();
//    //        var dbOptionsBuilder = new DbContextOptionsBuilder<TMovieDbContext>().UseSqlServer(configuration.GetConnectionString("TMConnection"));
//    //        return new TMovieDbContext(dbOptionsBuilder.Options);
//    //    }
//    //}



//.net core 2.0
using Evol.TMovie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
/// <summary>
/// Only for use EntityFramework-Migration
/// </summary>
//[Obsolete("升级到.net core 2.0 未实现...")]
public class TMovieDbContextMigrationFactory : IDesignTimeDbContextFactory<TMovieDbContext>
{
    public TMovieDbContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();
        var dbOptionsBuilder = (new DbContextOptionsBuilder<TMovieDbContext>()).UseSqlServer<TMovieDbContext>(configuration.GetConnectionString("TMConnection"));
        return new TMovieDbContext(dbOptionsBuilder.Options);
    }
}
