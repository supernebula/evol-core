using Evol.Domain.Events;
using System.Threading.Tasks;

namespace Evol.Domain.Messaging
{
    public interface IEventHandler<in T> where T : Event
    {
        /// <summary>
        /// Non-transactional event handle <see cref="ForkHandleAttribute"/>
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        Task HandleAsync(T @event);
    }
}
