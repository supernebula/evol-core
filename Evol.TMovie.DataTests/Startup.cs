using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Evol.Domain;
using Evol.Domain.Uow;
using Evol.EntityFramework.Uow;
using Evol.Domain.Messaging;
using Evol.EntityFramework.Repository;
using Microsoft.Extensions.Configuration;
using System.IO;
using Evol.TMovie.Data;

namespace Evol.TMovie.DataTests
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public IServiceCollection Services { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    Configuration = builder.Build();

            Services = new ServiceCollection();
            ConfigureServices(Services);

        }
        public void ConfigureServices(IServiceCollection services)
        {
            AppConfig.Init(services);
            services.AddDbContext<TMovieDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            ConfigureModules(services);
            AppConfig.Current.RegisterAppModuleFrom<TMovieDataTestModule>();
            var serviceProvider = services.BuildServiceProvider();
            AppConfig.ConfigServiceProvider(serviceProvider);
        }

        public void ConfigureModules(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IUnitOfWorkManager, EfUnitOfWorkManager>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<ICommandHandlerFactory, DefaultCommandHandlerFactory>();
            services.AddScoped<IEfDbContextProvider, EfUnitOfWorkDbContextProvider>();
        }
    }
}
