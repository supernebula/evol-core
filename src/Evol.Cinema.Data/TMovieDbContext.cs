using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Evol.EntityFramework;
using System;
using Evol.EntityFramework.Configueration;

namespace Evol.TMovie.Data
{

    public class TMovieDbContext : NamedDbContext
    {
        public TMovieDbContext() : this(null)
        {
        }

        public TMovieDbContext(DbContextOptions<TMovieDbContext> options) : base(options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            Name = nameof(TMovieDbContext);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //方法一
            //modelBuilder.AddConfiguration<FakeOrderMap>();
            //modelBuilder.AddConfiguration<FakeProductMap>();
            //modelBuilder.AddConfiguration<FakeUserMap>();
            ////方法二
            modelBuilder.AddConfigurationFromAssembly(this.GetType().GetTypeInfo().Assembly);
        }
    }
}
