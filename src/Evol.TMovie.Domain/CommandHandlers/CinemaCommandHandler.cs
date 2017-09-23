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
    public class CinemaCommandHandler : 
        ICommandHandler<CinemaCreateCommand>, 
        ICommandHandler<CinemaUpdateCommand>, 
        ICommandHandler<CinemaDeleteCommand>
    {
        public ICinemaRepository CinemaRepository { get; private set; }

        //public IEventBus EventBus { get; private set; }

        public CinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            CinemaRepository = cinemaRepository;
        }
        public async Task ExecuteAsync(CinemaCreateCommand command)
        {
            var item = command.Input.Map<Cinema>();
            item.Id = Guid.NewGuid();
            item.Name = item.Name;
            item.Address = item.Address;
            item.CreateTime = DateTime.Now;
            await CinemaRepository.InsertAsync(item);
        }

        public async Task ExecuteAsync(CinemaUpdateCommand command)
        {
            var item = await CinemaRepository.FindAsync(command.Input.Id);
            if (item == null)
                throw new KeyNotFoundException();
            item.Name = command.Input.Name;
            item.Address = command.Input.Address;
            await CinemaRepository.UpdateAsync(item);
        }

        public async Task ExecuteAsync(CinemaDeleteCommand command)
        {
            await CinemaRepository.DeleteAsync(command.Input.Id);
        }
    }
}
