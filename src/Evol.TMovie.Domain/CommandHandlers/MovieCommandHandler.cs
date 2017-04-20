using System;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Repositories;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.Domain.Events;
using Evol.TMovie.Domain.Dto;
using System.Collections.Generic;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class MovieCommandHandler : ICommandHandler<MovieCreateCommand>, ICommandHandler<MovieUpdateCommand>, ICommandHandler<MovieDeleteCommand>
    {

        public IMovieRepository MovieRepository { get; set; }

        public MovieCommandHandler(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        public async Task ExecuteAsync(MovieCreateCommand command)
        {
            var item = command.Input.Map<Movie>();
            item.Id = Guid.NewGuid();
            item.Title = item.Title ?? string.Empty;
            //....更多字段
            item.CreateTime = DateTime.Now;
            await MovieRepository.InsertAsync(item);
            command.Events.Add(new Event(item));
        }

        public async Task ExecuteAsync(MovieUpdateCommand command)
        {
            var item = await MovieRepository.FindAsync(command.Input.Id);
            if (item == null)
                throw new KeyNotFoundException();
            item.Title = command.Input.Name;
            //....更多字段
            MovieRepository.Update(item);
        }

        public Task ExecuteAsync(MovieDeleteCommand command)
        {
            MovieRepository.Delete(command.Input.Id);
            return Task.FromResult(1);
        }
    }
}
