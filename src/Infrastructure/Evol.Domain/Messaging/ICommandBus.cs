using System.Threading.Tasks;
using Evol.Domain.Commands;

namespace Evol.Domain.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;

        Task SendAsync<T>(T command) where T : Command;
    }
}
