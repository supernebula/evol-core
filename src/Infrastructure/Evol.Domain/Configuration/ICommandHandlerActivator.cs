using Evol.Domain.Commands;
using Evol.Domain.Messaging;

namespace Evol.Domain.Configuration
{
    public interface ICommandHandlerActivator
    {
        ICommandHandler<T> Create<T>() where T : Command;
    }
}
