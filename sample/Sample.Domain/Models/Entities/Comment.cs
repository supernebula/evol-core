using Evol.Common;
using Sample.Domain.Models.Values;
using System;

namespace Sample.Domain.Models.Entities
{
    public class Comment : BaseEntity<Guid>
    {
        public Guid PostId { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public CommentStatus Status { get; set; }
    }
}
