//using System;
//using System.Collections.Generic;
//using Microsoft.Extensions.DependencyInjection;
//using Evol.TMovie.Data;
//using Evol.EntityFramework.Uow;
//using Evol.Domain.Messaging;
//using Evol.EntityFramework.Repository;
//using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration.Json;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.FileProviders;
//using Microsoft.Extensions.Logging.Abstractions;
//using Evol.Configuration;

//namespace Evol.TMovie.Manage.Tests
//{
//    public static class Startup
//    {
//        private static IServiceCollection _services;

//        //public static IServiceProvider service => _serviceProvider;

//        private static IServiceProvider _serviceProvider;

//        public static IConfiguration Configuration { get; private set; }

//        public static ILoggerFactory LoggerFactory { get; private set; }

//        public static void Init()
//        {
//            _services = new ServiceCollection();
//            LoggerFactory = new NullLoggerFactory();
                
//            var configsProviders = new List<IConfigurationProvider>();
//            configsProviders.Add(new JsonConfigurationProvider(new JsonConfigurationSource() {
//                FileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory),
//                Path = "appsettings.json"
//            })
//                );
//            Configuration = new ConfigurationRoot(configsProviders);

//            Configure(LoggerFactory);
//            ConfigureServices(_services);
//        }

//        private static void ConfigureServices(IServiceCollection services)
//        {
//            AppConfig.Init(_services);
//            _services.AddDbContext<TMovieDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TMConnection")));

//            ConfigureApp(_services);
//            AppConfig.ConfigServiceProvider(_services.BuildServiceProvider());

//            _services.AddMvc();
//            //_services.AddTransient<CinemaApiController>();
//            _serviceProvider = _services.BuildServiceProvider();
//            AppConfig.ConfigServiceProvider(_serviceProvider);
//        }


//        private static void ConfigureApp(IServiceCollection services)
//        {
//            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
//            services.AddScoped<IUnitOfWorkManager, EfUnitOfWorkManager>();
//            services.AddScoped<ICommandBus, CommandBus>();
//            services.AddScoped<ICommandHandlerFactory, DefaultCommandHandlerFactory>();
//            services.AddScoped<IEventBus, EventBus>();
//            services.AddScoped<IEventHandlerFactory, DefaultEventHandlerFactory>();
//            services.AddScoped<IEfDbContextProvider, EfDbContextProvider>();
//            services.AddScoped<IEfUnitOfWorkDbContextProvider, EfUnitOfWorkDbContextProvider>();
//            AppConfig.Current.RegisterAppModuleFrom<TMovieManageTestModule>();
//        }

//        public static void Configure(ILoggerFactory loggerFactory)
//        {
//            LoggerFactory.AddProvider(NullLoggerProvider.Instance);
//        }

//        public static void Clear()
//        {
//            _services = null;
//            _serviceProvider = null;
//            Configuration = null;
//        }




//    }
//}
