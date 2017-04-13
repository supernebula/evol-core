using Evol.Domain;
using Evol.Domain.Messaging;
using Evol.Domain.Uow;
using Evol.EntityFramework.Repository;
using Evol.EntityFramework.Uow;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Evol.TMovie.Manage
{
    public partial class Startup
    {
        public void ConfigureModules(IServiceCollection services)
        {
            AppConfig.Current.InitModuleFrom<TMovieManageModule>();
            //services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            //services.AddScoped<IUnitOfWorkManager, EfUnitOfWorkManager>();
            //services.AddScoped<ICommandBus, CommandBus>();
            //services.AddScoped<ICommandHandlerFactory, DefaultCommandHandlerFactory>();
            //services.AddScoped<IEfDbContextProvider, EfUnitOfWorkDbContextProvider>();

            ////AppConfig.Current.Container.RegisterType<IUserSession, UserSession>(new PerThreadLifetimeManager());
            ////AppConfig.Current.Container.RegisterType<ICommandHandlerActivator, DefaultCommandHandlerFactory.DefaultCommandHandlerActivator>(new PerThreadLifetimeManager());
        }

        public void ConfigureModules(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            containerBuilder.RegisterType<EfUnitOfWorkManager>().As<IUnitOfWorkManager>().InstancePerRequest();
            containerBuilder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerRequest();
            containerBuilder.RegisterType<DefaultCommandHandlerFactory>().As<ICommandHandlerFactory>().InstancePerRequest();
            containerBuilder.RegisterType<EfUnitOfWorkDbContextProvider>().As<IEfDbContextProvider>().InstancePerRequest();
        }
    }
}
