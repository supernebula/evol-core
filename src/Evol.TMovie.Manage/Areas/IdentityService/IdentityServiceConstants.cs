using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Service.Extensions;

namespace Evol.TMovie.Manage.Identity
{
    // These values are used to setup the identity servcie and should not be changed
    public class IdentityServiceConstants
    {
        // Name of the single identity service tenant
        public const string Tenant = "IdentityService";
        
        // Unique ID of the single identity service tenant
        public const string TenantId = "78C965D3-DAE2-4EE5-86F4-313D27BD70B6";

        // Default policy for the identity service
        public const string DefaultPolicy = "signinsignup";

        // Identity service version
        public const string Version = "2.0";

        // Identity service token version
        public const string TokenVersion = "1.0";
    }
}
