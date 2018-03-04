using System;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Evol.TMovie.Data.Map
{
    public class ScreeningRoomMap : EntityConfigMap<ScreeningRoom>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("ScreeningRoom");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.SpaceType).IsRequired();
            builder.Ignore(e => e.Seats);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
