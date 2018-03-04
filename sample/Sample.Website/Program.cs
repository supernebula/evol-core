using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseKestrel(options =>
                //{
                //    options.Listen(IPAddress.Loopback, 5000);
                //    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                //    {
                //        listenOptions.UseHttps("testCert.pfx", "testPassword");
                //    });
                //})
                .Build();


        //APS.NET Core 1.1
        //var host = new WebHostBuilder()
        //.UseKestrel()
        //.UseAzureAppServices()
        //.UseContentRoot(Directory.GetCurrentDirectory())
        //.UseIISIntegration()
        //.UseStartup<Startup>()
        //.UseApplicationInsights()
        //.Build();
        //host.Run();
    }
}
