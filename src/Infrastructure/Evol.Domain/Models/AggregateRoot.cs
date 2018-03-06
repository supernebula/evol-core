using Evol.Common;

namespace Evol.Domain.Models
{
    public class AggregateRoot : BaseEntity, IAggregateRoot
    {
    }

    public class AggregateRoot<TKey> : BaseEntity<TKey>, IAggregateRoot<TKey>
    {
    }
}
