using Evol.EntityFramework.Configueration;
using Evol.TMovie.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{
    public class EmployeePermissionShipMap : EntityConfigMap<EmployeePermissionShip>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("EmployeePermissionShip");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EmployeeId).IsRequired();
            builder.Property(e => e.RoleId).IsRequired(false);
            builder.Property(e => e.CustomPermissionId).IsRequired(false);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
