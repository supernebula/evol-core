using System.Reflection;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;
using Evol.TMovie.Domain.Dto;

namespace Evol.TMovie.Domain
{
    public class TMovieDomainModule : AppModule
    {
        private readonly IConventionalDependencyRegister _domainDependencyRegister;

        public TMovieDomainModule()
        {
            _domainDependencyRegister = new DefualtDomainConventionalDependencyRegister();

        }

        public override void Initailize()
        {
            (new ObjectToObjectMapInitiator()).Init(this.GetType().GetTypeInfo().Assembly);
            _domainDependencyRegister.Register(IoCManager.Container, this.GetType().GetTypeInfo().Assembly); //Assembly.GetExecutingAssembly()
            base.Initailize();
        }
    }
}
