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
            //等价于HttpContext.Current
            var httpContextAccessor = servProvider.GetService<IHttpContextAccessor>();
            var currenthttpContext = httpContextAccessor.HttpContext;

            servProvider = currenthttpContext.RequestServices;
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
            //等价于HttpContext.Current
            var httpContextAccessor = servProvider.GetService<IHttpContextAccessor>();
            var currenthttpContext = httpContextAccessor.HttpContext;

            servProvider = currenthttpContext.RequestServices;
            if (servProvider == default(IServiceProvider))
                return default(IEnumerable<T>);
            var objs = servProvider.GetServices<T>();
            return objs;
        }
    }
}
