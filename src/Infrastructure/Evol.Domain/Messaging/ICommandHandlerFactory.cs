using Evol.Domain.Commands;

namespace Evol.Domain.Messaging
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}
