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
        ICommandHandler<ScheduleCreateCommand>, 
        ICommandHandler<ScheduleUpdateCommand>, 
        ICommandHandler<ScheduleDeleteCommand>
    {
        public IEventBus EventBus { get; private set; }

    public IScheduleRepository ScheduleRepository { get; set; }

    public ScreeningCommandHandler(IScheduleRepository scheduleRepository)
    {
            ScheduleRepository = scheduleRepository;
    }

        public async Task ExecuteAsync(ScheduleCreateCommand command)
        {
            var item = command.Input.Map<Schedule>();
            item.Id = Guid.NewGuid();
            item.CreateTime = DateTime.Now;
            await ScheduleRepository.InsertAsync(item);
        }

        public async Task ExecuteAsync(ScheduleUpdateCommand command)
        {
            var item = await ScheduleRepository.FindAsync(command.Input.Id);
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
            await ScheduleRepository.UpdateAsync(item);
        }

        public async Task ExecuteAsync(ScheduleDeleteCommand command)
        {
            await ScheduleRepository.DeleteAsync(command.Input.Id);
        }
    }
}
