using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sample.Storage;
using Evol.Extensions.Configuration;

namespace Sample.Website
{
    public class Startup
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

        ///// <summary>
        ///// 自定义强类型配置
        ///// </summary>
        //public ITypedConfigurationRoot TypedConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EvolSampleDbContext>(options =>
        options.UseMySQL(Configuration.GetConnectionString("evolsampleConnection")));
            services.AddMvc();

            // Add application services.

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
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
