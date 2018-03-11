using Evol.Domain.Events;
using Evol.Domain.Models;

namespace Sample.Domain.Events
{
    public class UserCreateEvent : Event
    {
        public UserCreateEvent(IAggregateRoot aggregateRoot) : base(aggregateRoot)
        {
        }
    }
}
