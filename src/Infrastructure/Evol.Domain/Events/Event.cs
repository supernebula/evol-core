using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.Domain.Messaging;
using Evol.Domain.Models;

namespace Evol.Domain.Events
{
    public class Event : IEvent
    {
        public Event(IAggregateRoot aggregateRoot)
        {
            Id = Guid.NewGuid();
            EntityId = aggregateRoot.Id;
            EntityType = aggregateRoot.GetType().FullName;
        }

        public Guid Id { get; private set; }

        string Type { get; }

        /// <summary>
        /// AggregateRoot Type
        /// </summary>
        string EntityType { get; }

        /// <summary>
        /// AggregateRoot Id
        /// </summary>
        Guid EntityId { get; }

        /// <summary>
        /// JSON of event property
        /// </summary>
        object Data { get; }

    }
}
