using Evol.EntityFramework.Configueration;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{
    public class CinemaMap : EntityConfigMap<Cinema>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Cinema");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(500);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
