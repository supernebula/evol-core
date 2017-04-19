using Evol.Domain.Events;
using System.Threading.Tasks;

namespace Evol.Domain.Messaging
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T @event) where T : Event;
    }
}
