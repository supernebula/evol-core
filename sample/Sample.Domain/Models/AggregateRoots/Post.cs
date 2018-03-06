using Evol.Domain.Models;
using System;

namespace Sample.Domain.Models.AggregateRoots
{
    public class Post : AggregateRoot<string>
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string Tag { get; set; }

        public string UserId { get; set; }

    }
}
