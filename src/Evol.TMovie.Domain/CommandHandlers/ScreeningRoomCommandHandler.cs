using System;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Repositories;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.Domain.Dto;
using System.Collections.Generic;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class ScreeningRoomCommandHandler :
        ICommandHandler<ScreeningRoomCreateCommand>,
        ICommandHandler<ScreeningRoomUpdateCommand>,
        ICommandHandler<ScreeningRoomDeleteCommand>
    {
        public IScreeningRoomRepository ScreeningRoomRepository { get; private set; }

        public ScreeningRoomCommandHandler(IScreeningRoomRepository screeningRoomRepository)
        {
            ScreeningRoomRepository = screeningRoomRepository;
        }

        public async Task ExecuteAsync(ScreeningRoomCreateCommand command)
        {
            var item = command.Input.Map<ScreeningRoom>();
            item.Id = Guid.NewGuid();
            item.Title = item.Title ?? string.Empty;
            item.CreateTime = DateTime.Now;
            await ScreeningRoomRepository.InsertAsync(item);
        }

        public async Task ExecuteAsync(ScreeningRoomUpdateCommand command)
        {
            var item = await ScreeningRoomRepository.FindAsync(command.Input.Id);
            if (item == null)
                throw new KeyNotFoundException();
            var dto = command.Input;

            //map 更多字段
            throw new NotImplementedException();

            await ScreeningRoomRepository.UpdateAsync(item);
        }

        public async Task ExecuteAsync(ScreeningRoomDeleteCommand command)
        {
            await ScreeningRoomRepository.DeleteAsync(command.Input.Id);
        }


    }
}
