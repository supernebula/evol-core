using Evol.Domain.Messaging;
using Sample.Domain.Commands;
using Sample.Domain.QueryEntries;
using Sample.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Sample.Domain.CommandHandlers
{
    public class UserCommandHandler :
        ICommandHandler<UserCreateCommand>,
        ICommandHandler<UserEditCommand>,
        ICommandHandler<UserChangePasswordCommand>

    {
        private IUserRepository userRepository;
        private IUserQueryEntry userQueryEntry;

        public UserCommandHandler(IUserRepository userRepos, IUserQueryEntry userQuery)
        {
            userRepository = userRepos;
            userQueryEntry = userQuery;
        }

        public Task ExecuteAsync(UserCreateCommand command)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(UserEditCommand command)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(UserChangePasswordCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

