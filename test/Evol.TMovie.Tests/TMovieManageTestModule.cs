
using Evol.Domain.Dto;
using Evol.Domain.Ioc;
using Evol.Configuration.Modules;
using System.Reflection;
using Evol.Configuration.IoC;
using Evol.Configuration;

namespace Evol.TMovie.Manage.Tests
{
    [DependOn(typeof(TMovieManageModule))]
    public class TMovieManageTestModule : AppModule
    {
        private readonly IConventionalDependencyRegister _tmTestDependencyRegister;

        public TMovieManageTestModule()
        {
            _tmTestDependencyRegister = new DefaultTManageTestConventionalDependencyRegister();
        }

        public override void Initailize()
        {
            DtoEntityMapInitiator.Create(this.GetType().GetTypeInfo().Assembly);
            _tmTestDependencyRegister.Register(AppConfig.Current.IoCManager, typeof(TMovieManageModule).GetTypeInfo().Assembly);
            InitDependModule<TMovieManageTestModule>();
            base.Initailize();
            DtoEntityMapInitiator.Initialize();
        }
    }
}

