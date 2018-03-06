using Evol.Common;
using Sample.Domain.Models.Values;
using System;

namespace Sample.Domain.Models.Entities
{
    public class Comment : BaseEntity<string>
    {
        public string PostId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public CommentStatus Status { get; set; }
    }
}
