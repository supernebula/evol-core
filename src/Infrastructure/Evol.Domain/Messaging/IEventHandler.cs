using Evol.Domain.Events;
using System.Threading.Tasks;

namespace Evol.Domain.Messaging
{
    public interface IEventHandler<in T> where T : Event
    {
        Task HandleAsync(T @event);
    }
}
