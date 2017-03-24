using Evol.EntityFramework.Configueration;
using Evol.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFramework.Repository.Test.Map
{
    public class FakeUserMap : EntityConfigMap<FakeUser>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Username).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(100);
            builder.Property(e => e.RealName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.Mobile).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Points).IsRequired();
            builder.Property(e => e.Points).IsRequired();
            builder.Property(e => e.PersonHeight).IsRequired();
            builder.Property(e => e.Birthday).IsRequired();
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
