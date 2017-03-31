using System;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.EntityFramework.Configueration;
using Microsoft.EntityFrameworkCore;

namespace Evol.Cinema.Data.Map
{
    public class ScreeningMap : EntityConfigMap<Screening>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Screening");
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
