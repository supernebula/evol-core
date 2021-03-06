﻿using System.Threading.Tasks;
using Evol.Domain.Commands;

namespace Evol.Domain.Messaging
{
    public interface ICommandHandler<in T> where T : Command
    {
        Task ExecuteAsync(T command);
    }
}
