using System.Reflection;
using Evol.Domain.Ioc;
using Evol.Configuration.Modules;
using Evol.Domain.Dto;
using Evol.Configuration.IoC;
using Evol.Configuration;

namespace Sample.Domain
{
    public class SampleDomainModule : AppModule
    {
        private readonly IConventionalDependencyRegister _domainDependencyRegister;

        public SampleDomainModule()
        {
            _domainDependencyRegister = new DefualtCqrsConventionalDependencyRegister();

        }

        public override void Initailize()
        {
            DtoEntityMapInitiator.Create(this.GetType().GetTypeInfo().Assembly);
            _domainDependencyRegister.Register(AppConfig.Current.IoCManager, this.GetType().GetTypeInfo().Assembly);
            base.Initailize();
            DtoEntityMapInitiator.Initialize();
        }
    }
}
