using System.Reflection;
using Evol.Configuration.Modules;
using Evol.Configuration.IoC;
using Evol.Configuration;
using Sample.Domain;

namespace Sample.Storage
{
    [DependOn(typeof(SampleDomainModule))]
    public class SampleStorageModule : AppModule
    {
        private readonly IConventionalDependencyRegister _dataDependencyRegister;

        public SampleStorageModule()
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
