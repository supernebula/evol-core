using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Service;
using Microsoft.AspNetCore.Identity.Service.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Evol.TMovie.Manage.Identity.Data;
using Evol.TMovie.Manage.Identity.Models;
using Evol.TMovie.Manage.Identity.Services;

// HostingStartup's in the primary assembly are run automatically.
[assembly: HostingStartup(typeof(Evol.TMovie.Manage.Identity.IdentityServiceStartup))]

namespace Evol.TMovie.Manage.Identity
{
    public class IdentityServiceStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                // Add framework services.
                services.AddDbContext<IdentityServiceDbContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityServiceDbContext>()
                    .AddDefaultTokenProviders();

                services.AddTransient<IEmailSender, AuthMessageSender>();
                services.AddTransient<ISmsSender, AuthMessageSender>();

                services.AddIdentityService<ApplicationUser, IdentityServiceApplication>(context.Configuration)
                    .AddIdentityServiceExtensions()
                    .AddEntityFrameworkStores<IdentityServiceDbContext>();

                // Add external authentication handlers below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            });
        }
    }
}