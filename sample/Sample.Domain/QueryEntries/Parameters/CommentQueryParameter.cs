using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.QueryEntries.Parameters
{
    public class CommentQueryParameter
    {
        public Guid? PostId { get; set; }

        public Guid? UserId { get; set; }
    }
}
