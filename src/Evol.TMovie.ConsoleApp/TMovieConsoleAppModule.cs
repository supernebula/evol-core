using Evol.Domain.Modules;
using Evol.TMovie.Data;
using Evol.TMovie.Domain;

namespace Evol.TMovie.ConsoleApp
{
    [DependOn(typeof(TMovieDataModule), typeof(TMovieDomainModule))]
    public class TMovieConsoleAppModule : AppModule
    {
        public override void Initailize()
        {
            InitDependModule<TMovieConsoleAppModule>();
            base.Initailize();
        }
    }
}
