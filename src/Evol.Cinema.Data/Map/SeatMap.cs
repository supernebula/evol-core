using System;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entitys;
using Evol.EntityFramework.Configueration;
using Microsoft.EntityFrameworkCore;

namespace Evol.TMovie.Data.Map
{
    public class SeatMap : EntityConfigMap<Seat>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Seat");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.SeatType);
            builder.Property(e => e.RowNo);
            builder.Property(e => e.ColumnNo);
            builder.Property(e => e.Status);
            builder.Property(e => e.CreateTime).IsRequired();

            builder.Property(e => e.ScreeningRoomId).IsRequired();
        }
    }
}
