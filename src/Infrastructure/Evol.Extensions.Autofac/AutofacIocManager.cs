using Evol.Common.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Autofac;

namespace Evol.Extensions.Autofac
{
    public class AutofacIocManager : IIoCManager, IDisposable
    {
        private readonly ContainerBuilder _builder;

        protected Func<IServiceProvider> ServiceProviderChunk { get; private set; }

        public AutofacIocManager(ContainerBuilder builder, Func<IServiceProvider> serviceProviderChunk)
        {
            _builder = builder;
            ServiceProviderChunk = serviceProviderChunk;
            _builder.RegisterInstance<IIoCManager>(this);
        }

        public void AddPerDependency(Type @interface, Type Impl)
        {
            _builder.RegisterType(Impl).As(@interface).InstancePerDependency();
        }

        public void AddPerDependency<TInterface, TImpl>() where TImpl : TInterface
        {
            _builder.RegisterType<TImpl>().As<TInterface>().InstancePerDependency();
        }

        public void AddPerRequest(Type @interface, Type Impl)
        {
            _builder.RegisterType(Impl).As(Impl).InstancePerLifetimeScope(); //.InstancePerRequest();
        }

        public void AddPerRequest<TInterface, TImpl>() where TImpl : TInterface
        {
            _builder.RegisterType<TImpl>().As<TInterface>().InstancePerLifetimeScope(); 
        }

        public void AddSingleInstance(Type @interface, Type Impl)
        {
            _builder.RegisterType(Impl).As(Impl).SingleInstance();
        }

        public void AddSingleInstance<TInterface, TImpl>() where TImpl : TInterface
        {
            _builder.RegisterType<TImpl>().As<TInterface>().SingleInstance();
        }

        public void AddSingleInstance<TInterface>(TInterface instance) where TInterface : class
        {
            _builder.RegisterInstance(instance).As<TInterface>().SingleInstance();
        }

        public void Dispose()
        {
        }

        public virtual T GetService<T>()
        {
            var servProvider = ServiceProviderChunk.Invoke();
            if (servProvider == default(IServiceProvider))
                return default(T);
            var obj = servProvider.GetService<T>();
            return obj;
        }

        public virtual IEnumerable<T> GetServices<T>()
        {
            var servProvider = ServiceProviderChunk.Invoke();
            if (servProvider == default(IServiceProvider))
                return default(IEnumerable<T>);
            var objs = servProvider.GetServices<T>();
            return objs;
        }
    }
}
