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
    class ScreeningCommandHandler:
        ICommandHandler<ScreeningCreateCommand>, 
        ICommandHandler<ScreeningUpdateCommand>, 
        ICommandHandler<ScreeningDeleteCommand>
    {
        public IEventBus EventBus { get; private set; }

    public IScreeningRepository ScreeningRepository { get; set; }

    public ScreeningCommandHandler(IScreeningRepository screeningRepository)
    {
            ScreeningRepository = screeningRepository;
    }

        public async Task ExecuteAsync(ScreeningCreateCommand command)
        {
            var item = command.Input.Map<Screening>();
            item.Id = Guid.NewGuid();
            item.CreateTime = DateTime.Now;
            await ScreeningRepository.InsertAsync(item);
        }

        public async Task ExecuteAsync(ScreeningUpdateCommand command)
        {
            var item = await ScreeningRepository.FindAsync(command.Input.Id);
            if (item == null)
                throw new KeyNotFoundException();
            var dto = command.Input;
            item.MovieId = dto.MovieId;
            item.CinemaId = dto.CinemaId;
            item.StartTime = dto.StartTime;
            item.StartTime = dto.StartTime;
            item.ScreeningRoomId = dto.ScreeningRoomId;
            item.SellPrice = dto.SellPrice;
            item.SpaceType = dto.SpaceType;
            await ScreeningRepository.UpdateAsync(item);
        }

        public async Task ExecuteAsync(ScreeningDeleteCommand command)
        {
            await ScreeningRepository.DeleteAsync(command.Input.Id);
        }
    }
}
