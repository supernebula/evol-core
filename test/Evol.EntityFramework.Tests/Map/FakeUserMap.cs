using System.Data.Entity.ModelConfiguration;
using Evol.Test.Model;

namespace Evol.EntityFramework.Repository.Test.Map
{
    public class FakeUserMap : EntityTypeConfiguration<FakeUser>
    {
        public FakeUserMap()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Username).IsRequired().HasMaxLength(100);
            this.Property(e => e.Password).IsRequired().HasMaxLength(100);
            this.Property(e => e.RealName).IsRequired().HasMaxLength(100);
            this.Property(e => e.Gender).IsRequired();
            this.Property(e => e.Mobile).IsOptional().HasMaxLength(100);
            this.Property(e => e.Email).IsRequired().HasMaxLength(100);
            this.Property(e => e.Address).IsRequired().HasMaxLength(500);
            this.Property(e => e.Points).IsRequired();
            this.Property(e => e.Points).IsRequired();
            this.Property(e => e.PersonHeight).IsRequired();
            this.Property(e => e.Birthday).IsRequired();
            this.Property(e => e.CreateTime).IsRequired();
        }
    }
}
