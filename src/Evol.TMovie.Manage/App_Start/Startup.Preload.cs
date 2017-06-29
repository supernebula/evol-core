using Evol.TMovie.Domain.QueryEntries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage
{
    public partial class Startup
    {
        public void PerLoad(IServiceCollection serviceCollection, IServiceProvider provider)
        {
           

        }

        private void LoadPermissionPlist(IServiceCollection services, IServiceProvider provider)
        {
            var permissionQuery = provider.GetService<IPermissionQueryEntry>();
            var permissions = permissionQuery.AllAsync().GetAwaiter().GetResult();

            services.AddAuthorization(options =>
            {
                foreach (var item in permissions)
                {
                    options.AddPolicy(item.Code, policy => policy.RequireClaim("permission", item.Code));
                }
            });
            
        }


    }
}
