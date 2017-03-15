using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Demo.Web.Extensions.DependencyInjection
{
    public static class IdentityRepositoryBuilderExtensions
    {
        public static IdentityBuilder AddServiceRepositorys<TService>(this IdentityBuilder builder)
        {

            throw new NotImplementedException();
        }
        public static IdentityBuilder AddServiceRepositorys<TContext, TKey>(this IdentityBuilder builder)
        {
            throw new NotImplementedException();
        }
    }

    
}
