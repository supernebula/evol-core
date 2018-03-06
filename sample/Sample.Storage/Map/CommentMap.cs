using Evol.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Models.Entities;

namespace Sample.Storage.Map
{
    public class CommentMap : EntityConfigMap<Comment>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Comment");
            builder.HasKey(e => e.Id); //.HasAnnotation(nameof(Comment.Id), new { TypeName = "varchar(36)" });
            builder.Property(e => e.PostId); //.HasAnnotation(nameof(Comment.Id), new { TypeName = "varchar(36)" }).IsRequired();
            builder.Property(e => e.Content).IsRequired().HasMaxLength(500);
            builder.Property(e => e.UserId); //.HasAnnotation(nameof(Comment.Id), new { TypeName = "varchar(36)" }).IsRequired();
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
