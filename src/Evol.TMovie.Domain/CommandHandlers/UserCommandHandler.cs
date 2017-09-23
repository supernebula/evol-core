using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using System;
using System.Collections.Generic;
using Evol.Domain.Dto;
using System.Threading.Tasks;
using Evol.Domain.Events;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class UserCommandHandler :
        ICommandHandler<UserCreateCommand>,
        ICommandHandler<UserUpdateCommand>,
        ICommandHandler<UserDeleteCommand>
    {
        public IUserRepository UserRepository { get; set; }

        public UserCommandHandler(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task ExecuteAsync(UserCreateCommand command)
        {
            var item = command.Input.Map<User>();
            item.Id = Guid.NewGuid();
            item.CreateTime = DateTime.Now;
            await UserRepository.InsertAsync(item);
        }

        public Task ExecuteAsync(UserUpdateCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task ExecuteAsync(UserDeleteCommand command)
        {
            await UserRepository.DeleteAsync(command.Input.Id);
        }
    }
}
