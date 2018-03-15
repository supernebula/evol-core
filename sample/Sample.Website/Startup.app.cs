using Autofac;
using Evol.Configuration;
using Evol.Domain.Messaging;
using Evol.EntityFrameworkCore.MySql.Repository;
using Evol.EntityFrameworkCore.MySql.Uow;
using Evol.Extensions.Autofac;
using Evol.Extensions.Autofac.AspnetCore;
using Evol.UnitOfWork.Abstractions;
using System;

namespace Sample.Website
{
    public partial class Startup
    {
        public void ConfigAppPerInit(ContainerBuilder containerBuilder, Func<IServiceProvider> serviceProviderFunc)
        {
            AppConfig.Init(new AspnetCoreAutofacIocManager(containerBuilder, serviceProviderFunc));
        }

        public void ConfigApp()
        {
            var ioCManager = AppConfig.Current.IoCManager;
            ioCManager.AddPerRequest<Evol.Common.Logging.ILoggerFactory, Evol.Logging.AdapteNLog.NLoggerFactory>();
            ioCManager.AddPerDependency<IUnitOfWork, EfCoreUnitOfWork>();
            ioCManager.AddPerRequest<IUnitOfWorkManager, EfCoreUnitOfWorkManager>();
            ioCManager.AddPerRequest<ICommandBus, CommandBus>();
            ioCManager.AddPerRequest<ICommandHandlerFactory, DefaultCommandHandlerFactory>();
            ioCManager.AddPerRequest<IEventBus, EventBus>();
            ioCManager.AddPerRequest<IEventHandlerFactory, DefaultEventHandlerFactory>();
            ioCManager.AddPerRequest<IEfCoreDbContextProvider, EfCoreDbContextProvider>();
            ioCManager.AddPerRequest<IEfCoreUnitOfWorkDbContextProvider, EfCoreUnitOfWorkDbContextProvider>();

            AppConfig.Current.RegisterAppModuleFrom<SampleWebsiteModule>();
        }


    }
}
