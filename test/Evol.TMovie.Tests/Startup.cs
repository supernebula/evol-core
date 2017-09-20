using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Evol.Domain;
using Evol.TMovie.Data;
using Evol.Domain.Uow;
using Evol.EntityFramework.Uow;
using Evol.Domain.Messaging;
using Evol.EntityFramework.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Xml;
using Microsoft.Extensions.FileProviders;

namespace Evol.TMovie.Manage.Tests
{
    public static class Startup
    {
        private static IServiceCollection _services;

        //public static IServiceProvider service => _serviceProvider;

        private static IServiceProvider _serviceProvider;

        private static IConfiguration _onfigurationRoot;

        public static void Init()
        {
            var configsProviders = new List<IConfigurationProvider>();
            configsProviders.Add(new JsonConfigurationProvider(new JsonConfigurationSource() {
                FileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory),
                Path = "appsettings.json"
            })
                );
            _onfigurationRoot = new ConfigurationRoot(configsProviders);
            _services = new ServiceCollection();
            AppConfig.Init(_services);
            _services.AddDbContext<TMovieDbContext>(options => options.UseSqlServer(_onfigurationRoot.GetConnectionString("TMConnection")));

            ConfigureApp(_services);
            AppConfig.ConfigServiceProvider(_services.BuildServiceProvider());

            _services.AddMvc();
            _serviceProvider = _services.BuildServiceProvider();
        }


        public static void ConfigureApp(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IUnitOfWorkManager, EfUnitOfWorkManager>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<ICommandHandlerFactory, DefaultCommandHandlerFactory>();
            services.AddScoped<IEfDbContextProvider, EfDbContextProvider>();
            services.AddScoped<IEfUnitOfWorkDbContextProvider, EfUnitOfWorkDbContextProvider>();
            AppConfig.Current.RegisterAppModuleFrom<TMovieManageModule>();
        }

        public static void Clear()
        {
            _services = null;
            _serviceProvider = null;
            _onfigurationRoot = null;
        }




    }
}
