using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using System;
using System.Collections.Generic;
using Evol.Domain.Dto;
using System.Threading.Tasks;
using Evol.TMovie.Domain.QueryEntries;
using Evol.Util.Hash;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class UserCommandHandler :
        ICommandHandler<UserCreateCommand>,
        ICommandHandler<UserUpdateCommand>,
        ICommandHandler<UserDeleteCommand>
    {
        public IUserRepository UserRepository { get; set; }

        public IUserQueryEntry UserQueryEntry { get; set; }

        public UserCommandHandler(IUserRepository userRepository, IUserQueryEntry userQueryEntry)
        {
            UserRepository = userRepository;
            UserQueryEntry = userQueryEntry;
        }

        public async Task ExecuteAsync(UserCreateCommand command)
        {
            var dto = command.Input;
            var item = command.Input.Map<User>();
            item.Id = Guid.NewGuid();
            item.Salt = Guid.NewGuid().ToString();
            item.Password = HashUtil.Md5PasswordWithSalt(dto.Password, item.Salt);
            item.CreateTime = DateTime.Now;
            await UserRepository.InsertAsync(item);
        }

        public async Task ExecuteAsync(UserUpdateCommand command)
        {
            var dto = command.Input;
            var item = await UserQueryEntry.FindAsync(dto.Id);
            if (item == null)
                throw new KeyNotFoundException($"{nameof(dto.Id)}:{dto.Id}");
            item.Id = Guid.NewGuid();
            item.RealName = dto.RealName;
            item.Email = dto.Email ;
            item.Mobile = dto.Mobile;
            item.CreateTime = DateTime.Now;
        }

        public async Task ExecuteAsync(UserDeleteCommand command)
        {
            await UserRepository.DeleteAsync(command.Input.Id);
        }
    }
}
