using System;

namespace Evol.Common
{
    public interface IPrimaryKey : IPrimaryKey<Guid>
    {
    }

    public interface IPrimaryKey<TKey>
    {
        TKey Id { get; set; }
    }
}
