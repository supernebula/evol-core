using Evol.Configuration;
using Evol.Domain.Messaging;
using Evol.EntityFramework.Repository;
using Evol.EntityFramework.Uow;
using Evol.UnitOfWork.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.TMovie.Manage
{
    public partial class Startup
    {
        public void ConfigureApp(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IUnitOfWorkManager, EfUnitOfWorkManager>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<ICommandHandlerFactory, DefaultCommandHandlerFactory>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IEventHandlerFactory, DefaultEventHandlerFactory>();
            services.AddScoped<IEfDbContextProvider, EfDbContextProvider>();
            services.AddScoped<IEfUnitOfWorkDbContextProvider, EfUnitOfWorkDbContextProvider>();
            AppConfig.Current.RegisterAppModuleFrom<TMovieManageModule>();
            //IUserSession
        }
    }
}
