using System.Reflection;
using Evol.TMovie.Data.Ioc;
using Evol.TMovie.Domain;
using Evol.Domain.Ioc;
using Evol.Configuration.Modules;
using Evol.Configuration.IoC;
using Evol.Configuration;

namespace Evol.TMovie.Data
{
    [DependOn(typeof(TMovieDomainModule))]
    public class TMovieDataModule : AppModule
    {
        private readonly IConventionalDependencyRegister _dataDependencyRegister;

        public TMovieDataModule()
        {
            _dataDependencyRegister = new DataConventionalDependencyRegister();
        }

        public override void Initailize()
        {
            _dataDependencyRegister.Register(AppConfig.Current.IoCManager, this.GetType().GetTypeInfo().Assembly);
            base.Initailize();
        }
    }
}
