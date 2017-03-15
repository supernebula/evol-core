using System;

namespace Demo.Library.Components
{
    public class IEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }

    }


    public class IEntity<TKey>
    {

    }
}
