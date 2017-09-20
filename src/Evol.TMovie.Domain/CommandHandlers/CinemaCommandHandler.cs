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
    public class CinemaCommandHandler : ICommandHandler<RoleCreateCommand>, ICommandHandler<CinemaUpdateCommand>, ICommandHandler<CinemaDeleteCommand>
    {
        public ICinemaRepository CinemaRepository { get; set; }

        public CinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            CinemaRepository = cinemaRepository;
        }
        public async Task ExecuteAsync(RoleCreateCommand command)
        {
            var item = command.Input.Map<Cinema>();
            item.Id = Guid.NewGuid();
            item.Name = item.Name ?? string.Empty;
            item.Name = item.Address ?? string.Empty;
            item.CreateTime = DateTime.Now;
            await CinemaRepository.InsertAsync(item);
            command.Events.Add(new Event(item));
        }

        public async Task ExecuteAsync(CinemaUpdateCommand command)
        {
            var item = await CinemaRepository.FindAsync(command.Input.Id);
            if (item == null)
                throw new KeyNotFoundException();
            item.Name = command.Input.Name;
            item.Address = command.Input.Address;
            CinemaRepository.Update(item);
        }

        public Task ExecuteAsync(CinemaDeleteCommand command)
        {
            CinemaRepository.Delete(command.Input.Id);
            return Task.FromResult(1);
        }
    }
}
