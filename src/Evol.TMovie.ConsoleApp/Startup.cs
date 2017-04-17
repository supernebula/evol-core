using Evol.TMovie.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Evol.Domain;
using Evol.Domain.Uow;
using Evol.EntityFramework.Uow;
using Evol.EntityFramework.Repository;
using System.IO;
using System;

namespace Evol.TMovie.ConsoleApp
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<TMovieDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            AppConfig.Init(services);
            AppConfig.Current.RegisterAppModuleFrom<TMovieConsoleAppModule>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IActiveUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IEfDbContextProvider, EfUnitOfWorkDbContextProvider>();

            var serviceProvider = services.BuildServiceProvider();
            AppConfig.ConfigServiceProvider(serviceProvider);

        }
    }
}
