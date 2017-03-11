using System;

namespace Evol.Domain.Messaging
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
