using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Demo.Website.Data;
using Demo.Website.Models;
using Demo.Website.Services;
using NLog.Web;
using NLog.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Evol.Web.Middlewares;
using Evol.Extensions.Configuration;

namespace Demo.Website
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();


            //添加自定义配置
            var typedBuilder = new TypedConfigurationBuilder();
            typedBuilder.SetBasePath(Path.Combine(env.ContentRootPath, "config"));
            //.AddJsonFile<ModuleShip>("moudleShip.json", true, true)
            //.AddXmlFile<AdminArea>("areaCode.xml", true, true);
            TypedConfiguration = typedBuilder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        public ITypedConfigurationRoot TypedConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TMConnection")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddMvc();
            //needed for NLog.Web
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Add application services.
            services.AddScoped(provider => {
                var value = new SingleConfig() { Tick = DateTime.Now };
                return value;
            });


            //添加自定义配置到依赖注入
            foreach (ITypedConfiguration item in TypedConfiguration.Configurations)
            {
                services.AddScoped(item.StrongType, provider => {
                    var value = TypedConfiguration.GetValue(item.StrongType);
                    return value;
                });
            }


            services.AddScoped(provider => {
                var value = new SingleConfig() { Tick = DateTime.Now };
                return value;
            });

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory
                .AddConsole()
                .AddNLog();
            env.ConfigureNLog("nlog.config");

            app.UseVisitAudit();
            //add NLog.Web
            app.AddNLogWeb();

            var provider = new FileExtensionContentTypeProvider();
            // Add new mappings
            provider.Mappings[".log"] = "text/html";
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"log")),
                RequestPath = new PathString("/log"),
                ContentTypeProvider = provider
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"log")),
                RequestPath = new PathString("/log")
            });



            //app.UseFileServer(new FileServerOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //    Path.Combine(Directory.GetCurrentDirectory(), @"log")),
            //    RequestPath = new PathString("/log"),
            //    EnableDirectoryBrowsing = true,
            //    ContentTypeProvider = 
            //});



            //needed for non-NETSTANDARD platforms: configure nlog.config in your project root. NB: you need NLog.Web.AspNetCore package for this. 		
            




            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
