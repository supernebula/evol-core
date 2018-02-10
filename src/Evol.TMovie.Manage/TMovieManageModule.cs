using Evol.Configuration.Modules;
using Evol.TMovie.Data;
using Evol.TMovie.Domain;
using Evol.Domain.Dto;
using System.Reflection;

namespace Evol.TMovie.Manage
{
    [DependOn(typeof(TMovieDataModule), typeof(TMovieDomainModule))]
    public class TMovieManageModule : AppModule
    {
        public override void Initailize()
        {
            DtoEntityMapInitiator.Create(this.GetType().GetTypeInfo().Assembly);
            InitDependModule<TMovieManageModule>();
            base.Initailize();
            DtoEntityMapInitiator.Initialize();
        }
    }
}
