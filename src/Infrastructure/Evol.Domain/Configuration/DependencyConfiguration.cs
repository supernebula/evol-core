using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Evol.Domain.Messaging;
using Evol.Utilities;
using Unity.Mvc5;

namespace Evol.Domain.Configuration
{
    public class DependencyConfiguration
    {
        public IDependencyResolver DependencyResolver { get; }
        public IUnityContainer UnityContainer { get; }

        public DependencyConfiguration()
        {
            UnityContainer = new UnityContainer();
            DependencyResolver = new UnityDependencyResolver(UnityContainer);
        }

        public DependencyConfiguration(IUnityContainer unityContainer, IDependencyResolver dependencyResolver)
        {
            UnityContainer = unityContainer;
            DependencyResolver = dependencyResolver;
        }

        public T Resolve<T>()
        {
            return UnityContainer.Resolve<T>();
        }

        public void RegisterCommandBus<T>() where T : ICommandBus
        {
            var commandBusDependencyRegister = new CommandBusDependencyRegister(UnityContainer);
            commandBusDependencyRegister.Register(typeof(ICommandBus), typeof(T));
        }

        //public void RegisterCommandBus<T>() where T : ICommandBus
        //{
        //    var commandBusDependencyRegister = new CommandBusDependencyRegister(UnityContainer);
        //    commandBusDependencyRegister.Register(typeof(ICommandBus), typeof(T));
        //}

        public ICommandBus ResolveCommandBus
        {
            get
            {
                var commandBus = Resolve<ICommandBus>();
                if(commandBus == null)
                    throw new NullReferenceException("未注册" + nameof(ICommandBus) + "的实现类");
                return commandBus;
            }
        }

        public IEventBus ResolveEventdBus
        {
            get
            {
                var eventBus = Resolve<IEventBus>();
                if (eventBus == null)
                    throw new NullReferenceException("未注册" + nameof(IEventBus) + "的实现类");
                return eventBus;
            }
        }



        public void RegisterCommandBus(params string[] assemblyNames)
        {
            RegisterCommandBus(LoadAssembly(assemblyNames));
        }

        public void RegisterCommandBus(params Assembly[] assemblies)
        {
            var eventHandlerDependencyRegister = new CommandBusDependencyRegister(UnityContainer, assemblies);
            eventHandlerDependencyRegister.Register();
        }

        public void RegisterEventBus<T>() where T : IEventBus
        {
            var eventBusDependencyRegister = new EventBusDependencyRegister(UnityContainer);
            eventBusDependencyRegister.Register(typeof(IEventBus), typeof(T));
        }

        public void RegisterEventBus(params string[] assemblyNames)
        {
            RegisterEventBus(LoadAssembly(assemblyNames));
        }

        public void RegisterEventBus(params Assembly[] assemblies)
        {
            var eventBusDependencyRegister = new EventBusDependencyRegister(UnityContainer, assemblies);
            eventBusDependencyRegister.Register();
        }


        public void RegisterMessagingComponents(params string[] assemblyNames)
        {
            RegisterMessagingComponents(LoadAssembly(assemblyNames));
        }

        public void RegisterMessagingComponents(params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblies) + "数组为空");
            var commandHandlerDependencyRegister = new CommandHandlerDependencyRegister(UnityContainer, assemblies);
            commandHandlerDependencyRegister.Register();
            var eventHandlerDependencyRegister = new EventHandlerDependencyRegister(UnityContainer, assemblies);
            eventHandlerDependencyRegister.Register();
        }

        public void RegisterRepository(string interfaceNamespace, string classNamespace, params string[] assamblyNames)
        {
            RegisterRepository(interfaceNamespace, classNamespace, LoadAssembly(assamblyNames));
        }

        public void RegisterRepository(string interfaceNamespace, string classNamespace, params Assembly[] assemblies)
        {
            if(string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new ArgumentNullException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new ArgumentNullException(nameof(classNamespace));
            if (assemblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblies) + "数组为空");

            var interfaceClassPaires = IoCUtility.GetInterfaceAndClass( interfaceNamespace, classNamespace, assemblies);
            interfaceClassPaires.ForEach(p => UnityContainer.RegisterType(p.Interface, p.Impl, new PerThreadLifetimeManager()));
        }

        public void RegisterQueryEntry(string interfaceNamespace, string classNamespace, params string[] assamblyNames)
        {
            if (string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new ArgumentNullException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new ArgumentNullException(nameof(classNamespace));
            RegisterRepository(interfaceNamespace, classNamespace, LoadAssembly(assamblyNames));
        }

        public void RegisterQueryEntry(string interfaceNamespace, string classNamespace, params Assembly[] assemblies)
        {
            if (string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new ArgumentNullException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new ArgumentNullException(nameof(classNamespace));
            if (assemblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblies) + "数组为空");

            var interfaceClassPaires = IoCUtility.GetInterfaceAndClass(interfaceNamespace, classNamespace, assemblies);
            interfaceClassPaires.ForEach(p => UnityContainer.RegisterType(p.Interface, p.Impl, new PerThreadLifetimeManager()));
        }

        public Assembly[] LoadAssembly(params string[] assemblyNames)
        {
            if (assemblyNames.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblyNames) + "数组为空");
            var assemblies = new List<Assembly>();
            assemblyNames.ToList().ForEach(e => assemblies.Add(Assembly.Load(e)));
            return assemblies.ToArray();
        }
    }
}
