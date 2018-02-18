using Evol.Configuration.Modules;
using Sample.Domain;
using Evol.Domain.Dto;
using Sample.Storage;

namespace Sample.Website
{
    [DependOn(typeof(SampleDomainModule)), DependOn(typeof(SampleStorageModule))]
    public class SampleWebsiteModule : AppModule
    {
        public override void Initailize()
        {
            DtoEntityMapInitiator.Create(this.GetType().Assembly);
            InitDependModule<SampleWebsiteModule>();
            base.Initailize();
            DtoEntityMapInitiator.Initialize();
        }
    }
}

