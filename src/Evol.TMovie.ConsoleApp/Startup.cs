using Evol.TMovie.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Evol.Domain;
using Evol.Domain.Uow;
using Evol.EntityFramework.Uow;
using Evol.EntityFramework.Repository;
using System.IO;

namespace Evol.TMovie.ConsoleApp
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
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


            AppConfig.InitCurrent(services, services.BuildServiceProvider());
            AppConfig.Current.InitModuleFrom<TMovieConsoleAppModule>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IActiveUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IEfDbContextProvider, EfUnitOfWorkDbContextProvider>();

            services.AddDbContext<TMovieDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetService<TMovieDbContext>();

        }
    }
}
