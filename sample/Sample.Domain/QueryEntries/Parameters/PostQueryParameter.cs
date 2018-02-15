using System;

namespace Sample.Domain.QueryEntries.Parameters
{
    public class PostQueryParameter
    {
        public string Title { get; set; }

        public string Key { get; set; }


        public Guid? UserId { get; set; }
    }
}
