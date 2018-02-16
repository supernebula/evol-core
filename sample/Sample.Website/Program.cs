﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
