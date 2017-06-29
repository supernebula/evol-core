//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Microsoft.EntityFrameworkCore;
//using Evol.TMovie.Data;
//using Evol.Domain;
//using Evol.Web.Middlewares;
//using NLog.Web;
//using NLog.Extensions.Logging;
//using Microsoft.AspNetCore.Http;
//using Evol.TMovie.Manage.Extensions.DependencyInjection;
//using Evol.MongoDB.Repository;

//namespace Evol.TMovie.Manage
//{
//    public partial class Startup
//    {
//        public Startup(IHostingEnvironment env)
//        {
//            var builder = new ConfigurationBuilder()
//                .SetBasePath(env.ContentRootPath)
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
//                .AddEnvironmentVariables();
//            Configuration = builder.Build();
//        }

//        public IConfigurationRoot Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            AppConfig.Init(services);
//            services.AddDbContext<TMovieDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TMConnection")));
//            //services.AddMongoDbContext<LogMongoContext>(() => UseConnectionString(""));
//            ConfigureIdentity(services);
//            services.AddMvc();

//            //needed for NLog.Web
//            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//            // Add framework services.
//            ConfigureModules(services);
//            AppConfig.ConfigServiceProvider(services.BuildServiceProvider());

//            //services.Configure<IISOptions>(options => {
//            //    options.AutomaticAuthentication = true;
//            //    options.ForwardWindowsAuthentication = true;
//            //    options.ForwardClientCertificate = true;
//            //});

//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//        {


//            //app.Use(new Func<RequestDelegate, RequestDelegate>(nextApp => new ContainerMiddleware(nextApp, app.ApplicationServices).Invoke));
//            //add NLog to ASP.NET Core
//            loggerFactory.AddNLog();

//            //add NLog.Web
//            app.AddNLogWeb();

//            //needed for non-NETSTANDARD platforms: configure nlog.config in your project root. NB: you need NLog.Web.AspNetCore package for this. 		
//            env.ConfigureNLog("nlog.config");

//            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
//            loggerFactory.AddDebug();

//            app.UseStaticFiles();
//            //app.UseVisitAudit();

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseBrowserLink();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//            }

//            //.net core 1.1 升级 .net core 2.0 不支持
//            //app.UseCookieAuthentication(new CookieAuthenticationOptions()
//            //{
//            //    AuthenticationScheme = "MyCookieMiddlewareInstance",
//            //    LoginPath = new PathString("/Login/Login/"),
//            //    AutomaticAuthenticate = true,
//            //    AutomaticChallenge = true
//            //});

//            //

//            //app.UseUnhandledException();

//            app.UserAppConfigRequestServicesMiddleware();
//            app.UseIdentity();
//            app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "default",
//                    template: "{controller=Home}/{action=Index}/{id?}");
//            });
//        }
//    }
//}
