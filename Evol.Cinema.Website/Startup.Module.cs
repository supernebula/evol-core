using Evol.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Website
{
    public partial class Startup
    {
        public void ConfigureMudle(IServiceCollection services)
        {
            AppConfig.Current.InitModuleFrom<TMovieWebsiteModule>();
            //AppConfig.Current.RegisterType<IDbContextFactory, DefualtDbContextFactory>(new PerThreadLifetimeManager());
            //AppConfig.Current.Container.RegisterType<IActiveUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            //AppConfig.Current.Container.RegisterType<IUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            //AppConfig.Current.Container.RegisterType<ICommandBus, CommandBus>(new PerThreadLifetimeManager());
            //AppConfig.Current.Container.RegisterType<IUserSession, UserSession>(new PerThreadLifetimeManager());
            //AppConfig.Current.Container.RegisterType<ICommandHandlerFactory, DefaultCommandHandlerFactory>(new PerThreadLifetimeManager());
            //AppConfig.Current.Container.RegisterType<ICommandHandlerActivator, DefaultCommandHandlerFactory.DefaultCommandHandlerActivator>(new PerThreadLifetimeManager());

            //DependencyResolver.SetResolver(new UnityDependencyResolver(AppConfiguration.Current.Container));
        }
    }
}
