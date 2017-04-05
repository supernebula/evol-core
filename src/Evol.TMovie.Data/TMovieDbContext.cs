using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Evol.EntityFramework;
using System;
using Evol.EntityFramework.Configueration;
using Evol.TMovie.Data.Map;

namespace Evol.TMovie.Data
{

    public class TMovieDbContext : DbContext, INamedDbContext
    {
        public string Name { get; set; }

        public TMovieDbContext(DbContextOptions<TMovieDbContext> options) : base(options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            Name = nameof(TMovieDbContext);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //方法一
            //modelBuilder.AddConfiguration<CinemaMap>();
            //modelBuilder.AddConfiguration<MovieMap>();
            //modelBuilder.AddConfiguration<ActorMap>();
            //modelBuilder.AddConfiguration<ScreeningMap>();
            //modelBuilder.AddConfiguration<ScreeningRoomMap>();
            //modelBuilder.AddConfiguration<SeatMap>();
            ////方法二
            modelBuilder.AddConfigurationFromAssembly(this.GetType().GetTypeInfo().Assembly);
        }
    }
}
