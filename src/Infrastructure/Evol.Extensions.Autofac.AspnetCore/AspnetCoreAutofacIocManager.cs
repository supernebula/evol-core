using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Extensions.Autofac.AspnetCore
{
    public class AspnetCoreAutofacIocManager : AutofacIocManager
    {
        public AspnetCoreAutofacIocManager(ContainerBuilder builder, Func<IServiceProvider> serviceProviderChunk) 
            : base(builder, serviceProviderChunk)
        {
        }

        /// <summary>
        /// 支持per-request lifetime scope
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T GetService<T>()
        {
            var servProvider = ServiceProviderChunk.Invoke();
            var httpContextAccessor = servProvider.GetService<IHttpContextAccessor>();
            var httpContext = httpContextAccessor.HttpContext;
            servProvider = httpContext.RequestServices;

            if (servProvider == default(IServiceProvider))
                return default(T);
            var obj = servProvider.GetService<T>();
            return obj;
        }

        /// <summary>
        /// 支持per-request lifetime scope
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override IEnumerable<T> GetServices<T>()
        {
            var servProvider = ServiceProviderChunk.Invoke();
            var httpContextAccessor = servProvider.GetService<IHttpContextAccessor>();
            var httpContext = httpContextAccessor.HttpContext;
            servProvider = httpContext.RequestServices;

            if (servProvider == default(IServiceProvider))
                return default(IEnumerable<T>);
            var objs = servProvider.GetServices<T>();
            return objs;
        }
    }
}
