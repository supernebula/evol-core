using System.Reflection;
using Evol.Cinema.Data.Ioc;
using Evol.Cinema.Domain;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;

namespace Evol.Cinema.Data
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
