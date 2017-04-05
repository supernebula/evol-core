using Evol.Domain;
using Evol.Domain.Uow;
using Evol.EntityFramework.Repository;
using Evol.EntityFramework.Uow;
using Evol.TMovie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Evol.TMovie.ConsoleApp
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }
        private static IServiceCollection _services;

        static void Main(string[] args)
        {
            Console.WriteLine("startup..");
            _services = new ServiceCollection();
            new Startup().ConfigureServices(_services);
            Console.ReadKey();

        }
    }
}