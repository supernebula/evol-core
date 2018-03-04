using System;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Evol.TMovie.Data.Map
{
    public class ScheduleMap : EntityConfigMap<Schedule>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Schedule");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.StartTime);
            builder.Property(e => e.EndTime);
            builder.Property(e => e.ScreeningRoomId);
            builder.Property(e => e.MovieId);
            builder.Property(e => e.Price);
            builder.Property(e => e.SellPrice);
            builder.Property(e => e.SpaceType);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
