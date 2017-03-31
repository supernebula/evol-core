using System;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Cinema.Domain.Models.Entitys;
using Evol.EntityFramework.Configueration;
using Microsoft.EntityFrameworkCore;

namespace Evol.Cinema.Data.Map
{
    public class ScreeningRoomMap : EntityConfigMap<ScreeningRoom>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("ScreeningRoom");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.SpaceType).IsRequired();
            builder.Ignore(e => e.Seats);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
