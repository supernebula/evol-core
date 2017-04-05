using Evol.Domain.Modules;
using Evol.TMovie.Data;
using Evol.TMovie.Domain;

namespace Evol.TMovie.Manage
{
    [DependOn(typeof(TMovieDataModule), typeof(TMovieDomainModule))]
    public class TMovieManageModule : AppModule
    {
        public override void Initailize()
        {
            InitDependModule<TMovieManageModule>();
            base.Initailize();
        }
    }
}
