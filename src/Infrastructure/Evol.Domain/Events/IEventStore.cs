using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Domain.Events
{
    [Obsolete("未完成")]
    public interface IEventStore
    {
        Task AddAsync(Event @event);

        Task<Event> TakeAsync();

        Task<IEnumerable<Event>> TakeAsync(int num);

        Task DeleteAsync(Guid eventId);
    }
}
