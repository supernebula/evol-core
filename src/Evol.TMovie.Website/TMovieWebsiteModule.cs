using Evol.Domain.Modules;
using Evol.TMovie.Data;
using Evol.TMovie.Domain;

namespace Evol.TMovie.Website
{
    [DependOn(typeof(TMovieDataModule), typeof(TMovieDomainModule))]
    public class TMovieWebsiteModule : AppModule
    {
        public override void Initailize()
        {
            InitDependModule<TMovieWebsiteModule>();
            base.Initailize();
        }
    }
}
