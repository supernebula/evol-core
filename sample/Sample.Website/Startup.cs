using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sample.Storage;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Sample.Website.Core.Filters;
using Sample.Website.Core;

namespace Sample.Website
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            HostingEnvironment = env;
            Configuration = config;

            ////自定义强类型配置
            //var typedBuilder = new TypedConfigurationBuilder();
            //typedBuilder.SetBasePath(Path.Combine(env.ContentRootPath, "config"));
            ////.AddJsonFile<ModuleShip>("moudleShip.json", true, true)
            ////.AddXmlFile<AdminArea>("areaCode.xml", true, true);
            //TypedConfiguration = typedBuilder.Build();
        }

        public IHostingEnvironment HostingEnvironment { get; }

        public IConfiguration Configuration { get; }

        public IContainer AppContainer { get; private set; }

        ///// <summary>
        ///// 自定义强类型配置
        ///// </summary>
        //public ITypedConfigurationRoot TypedConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.Configure<IISOptions>(options =>
            //{
            //    options.ForwardClientCertificate = false;
            //});

            services.AddDbContext<EvolSampleDbContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("evolsampleConnection")));
            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(FriendExceptionFilterAttribute));
            }).AddControllersAsServices();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Sample.Website.xml");
                c.IncludeXmlComments(xmlPath);
            });

            // Add application services by autofac

            //为应用配置初始化IocManager
            IServiceProvider serviceProvider = null;
            var containerBuilder = new ContainerBuilder();

            ConfigAppPerInit(containerBuilder, () => serviceProvider);
            ConfigApp();
            containerBuilder.Populate(services);
            AppContainer = containerBuilder.Build();
            serviceProvider = new AutofacServiceProvider(AppContainer);
            return serviceProvider;

            ////添加自定义强类型配置到依赖注入
            //foreach (ITypedConfiguration item in TypedConfiguration.Configurations)
            //{
            //    services.AddScoped(item.StrongType, provider => {
            //        var value = TypedConfiguration.GetValue(item.StrongType);
            //        return value;
            //    });
            //}
            //services.AddScoped(provider => {
            //    var value = new SingleConfig() { Tick = DateTime.Now };
            //    return value;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                //app.UseDeveloperExceptionPage();
                app.UseCanContinueExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}" 
                );
            });
        }
    }
}
