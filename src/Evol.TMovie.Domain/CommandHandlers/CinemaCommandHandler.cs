using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using System;
using System.Collections.Generic;
using Evol.TMovie.Domain.Dto;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class CinemaCommandHandler : ICommandHandler<CinemaCreateCommand>, ICommandHandler<CinemaUpdateCommand>, ICommandHandler<CinemaDeleteCommand>
    {
        public ICinemaRepository CinemaRepository { get; set; }

        public CinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            CinemaRepository = cinemaRepository;
        }
        public Task ExecuteAsync(CinemaCreateCommand command)
        {
            var item = new Cinema();
            CinemaRepository.Insert(item);
            return Task.FromResult(1);
        }

        public Task ExecuteAsync(CinemaUpdateCommand command)
        {
            CinemaRepository.Update(command.Input.Map<Cinema>());
            return Task.FromResult(1);
        }

        public Task ExecuteAsync(CinemaDeleteCommand command)
        {
            CinemaRepository.Delete(command.Input.Id);
            return Task.FromResult(1);
        }
    }
}
