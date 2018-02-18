using System;
using System.Collections.Generic;
using Evol.Common.IoC;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace Evol.Fx.Extensions.Unity
{
    public class UnityIocManager : IIoCManager, IDisposable
    {

        private readonly IUnityContainer _container;

        public UnityIocManager(IUnityContainer container)
        {
            _container = container;
            _container.RegisterInstance<IIoCManager>(this);
        }

        public void AddPerDependency(Type @interface, Type Impl)
        {
            _container.RegisterType(@interface, Impl, new PerResolveLifetimeManager());
        }

        public void AddPerDependency<TInterface, TImpl>() where TImpl : TInterface
        {
            _container.RegisterType<TInterface, TImpl>(new PerResolveLifetimeManager());
        }

        public void AddPerRequest(Type @interface, Type Impl)
        {
            _container.RegisterType(@interface, Impl, new PerRequestLifetimeManager());
        }

        public void AddPerRequest<TInterface, TImpl>() where TImpl : TInterface
        {
            _container.RegisterType<TInterface, TImpl>(new PerRequestLifetimeManager());
        }

        public void AddSingleInstance(Type @interface, Type Impl)
        {
            _container.RegisterInstance(@interface, Impl);
        }

        public void AddSingleInstance<TInterface, TImpl>() where TImpl : TInterface
        {
            _container.RegisterInstance(typeof(TInterface), typeof(TImpl));
        }

        public void AddSingleInstance<TInterface>(TInterface instance) where TInterface : class
        {
            _container.RegisterInstance(instance);
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public T GetService<T>()
        {
            var obj = _container.Resolve<T>();
            return obj;
        }

        public IEnumerable<T> GetServices<T>()
        {
            var items = _container.ResolveAll<T>();
            return items;
        }
    }
}
