
using Evol.Domain.Dto;
using Evol.Domain.Ioc;
using Evol.Configuration.Modules;
using System.Reflection;

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
            DtoObjectMapInitiator.Create(this.GetType().GetTypeInfo().Assembly);
            _tmTestDependencyRegister.Register(IoCManager.Container, typeof(TMovieManageModule).GetTypeInfo().Assembly);
            InitDependModule<TMovieManageTestModule>();
            base.Initailize();
            DtoObjectMapInitiator.Initialize();
        }
    }
}

