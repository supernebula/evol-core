using System;

namespace Evol.Common
{
    public interface IEntity<TKey> : IPrimaryKey<TKey>
    {
        DateTime CreateTime { get; set; }
    }
}
