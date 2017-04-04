using System.Reflection;
using Evol.TMovie.Data.Ioc;
using Evol.TMovie.Domain;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;

namespace Evol.TMovie.Data
{
    [DependOn(typeof(CinemaDomainModule))]
    public class CinemaDataModule : AppModule
    {
        private readonly IConventionalDependencyRegister _dataDependencyRegister;

        public CinemaDataModule()
        {
            _dataDependencyRegister = new DataConventionalDependencyRegister();
        }

        public override void Initailize()
        {
            _dataDependencyRegister.Register(IoCManager.Container, Assembly.GetExecutingAssembly());
            base.Initailize();
        }
    }
}
