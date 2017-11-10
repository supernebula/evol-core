using Microsoft.Extensions.Configuration;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(EvolFx.TMovie.Website.Startup))]
namespace EvolFx.TMovie.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
    //        var builder = new ConfigurationBuilder()
    //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

    //        if (env.IsDevelopment())
    //        {
    //            // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
    //            //builder.AddUserSecrets<Startup>();
    //        }

    //        builder.AddEnvironmentVariables();
    //        ConfigurationRoot = builder.Build();


            ConfigureAuth(app);
        }
    }
}
