using System;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Repositories;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Models.AggregateRoots;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class MovieCommandHandler : ICommandHandler<MovieCreateCommand>, ICommandHandler<MovieUpdateCommand>, ICommandHandler<MovieDeleteCommand>
    {

        public IMovieRepository MovieRepository { get; set; }

        public MovieCommandHandler(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        public void Execute(MovieCreateCommand command)
        {
            var item = new Movie();
            MovieRepository.Insert(item);
        }

        public void Execute(MovieUpdateCommand command)
        {
            MovieRepository.Update(command.AggregateRoot);
        }

        public void Execute(MovieDeleteCommand command)
        {
            MovieRepository.Delete(command.AggregateRootId);
        }

        public Task ExecuteAsync(MovieCreateCommand command)
        {
            var item = new Movie();
            MovieRepository.Insert(item);
            return Task.FromResult(1);
        }

        public Task ExecuteAsync(MovieUpdateCommand command)
        {
            MovieRepository.Update(command.AggregateRoot);
            return Task.FromResult(1);
        }

        public Task ExecuteAsync(MovieDeleteCommand command)
        {
            MovieRepository.Delete(command.AggregateRootId);
            return Task.FromResult(1);
        }
    }
}
