using Evol.Domain.Models;
using System;

namespace Sample.Domain.Models.AggregateRoots
{
    public class Post : AggregateRoot<Guid>
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string Tag { get; set; }

        public Guid UserId { get; set; }

    }
}
