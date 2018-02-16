using System;
using Microsoft.EntityFrameworkCore;
using Evol.EntityFrameworkCore.SqlServer.Configueration;
using System.Reflection;

namespace Evol.EntityFrameworkCore.SqlServer.Tests
{
    public class TestDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Utest;Trusted_Connection=True;");
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
