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

        private readonly Func<IServiceProvider> _serviceProviderChunk;

        public AutofacIocManager(ContainerBuilder builder, Func<IServiceProvider> serviceProviderChunk)
        {
            _builder = builder;
            _serviceProviderChunk = serviceProviderChunk;
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
            _builder.RegisterType(Impl).As(Impl).InstancePerRequest();
        }

        public void AddPerRequest<TInterface, TImpl>() where TImpl : TInterface
        {
            _builder.RegisterType<TImpl>().As<TInterface>().InstancePerRequest();
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

        public T GetService<T>()
        {
            var servProvider = _serviceProviderChunk.Invoke();
            if (servProvider == default(IServiceProvider))
                return default(T);
            var obj = servProvider.GetService<T>();
            return obj;
        }

        public IEnumerable<T> GetServices<T>()
        {
            var servProvider = _serviceProviderChunk.Invoke();
            if (servProvider == default(IServiceProvider))
                return default(IEnumerable<T>);
            var objs = servProvider.GetServices<T>();
            return objs;
        }
    }
}
