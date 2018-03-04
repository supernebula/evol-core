using Evol.EntityFrameworkCore.Configuration;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{
    public class RoleMap : EntityConfigMap<Role>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Role");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
