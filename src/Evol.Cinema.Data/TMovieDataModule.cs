using System.Reflection;
using Evol.TMovie.Data.Ioc;
using Evol.TMovie.Domain;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;

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
            _dataDependencyRegister.Register(IoCManager.Container, this.GetType().GetTypeInfo().Assembly);
            base.Initailize();
        }
    }
}
