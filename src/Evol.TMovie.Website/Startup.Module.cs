using Evol.Domain;
using Evol.Domain.Configuration;
using Evol.Domain.Messaging;
using Evol.Domain.Uow;
using Evol.EntityFramework.Repository;
using Evol.EntityFramework.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.TMovie.Website
{
    public partial class Startup
    {
        public void ConfigureModules(IServiceCollection services)
        {
            AppConfig.Current.RegisterAppModuleFrom<TMovieWebsiteModule>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IActiveUnitOfWork, EfUnitOfWork>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<ICommandHandlerFactory, DefaultCommandHandlerFactory>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IEventHandlerFactory, DefaultEventHandlerFactory>();
            services.AddScoped<IEfDbContextProvider, EfDbContextProvider>();
            services.AddScoped<IEfUnitOfWorkDbContextProvider, EfUnitOfWorkDbContextProvider>();
            //AppConfig.Current.Container.RegisterType<IUserSession, UserSession>(new PerThreadLifetimeManager());
        }
    }
}
