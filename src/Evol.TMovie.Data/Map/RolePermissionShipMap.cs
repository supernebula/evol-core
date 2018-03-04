using Evol.EntityFrameworkCore.Configuration;
using Evol.TMovie.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{
    public class RolePermissionShipMap : EntityConfigMap<RolePermissionShip>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("RolePermissionShip");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RoleId).IsRequired();
            builder.Property(e => e.PermissionId).IsRequired();
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
