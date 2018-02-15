using System.Reflection;
using Evol.Configuration.Modules;
using Evol.Configuration.IoC;
using Evol.Configuration;
using Evol.TMovie.Domain;

namespace Sample.Storage
{
    [DependOn(typeof(SampleDomainModule))]
    public class SampleDataModule : AppModule
    {
        private readonly IConventionalDependencyRegister _dataDependencyRegister;

        public SampleDataModule()
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
