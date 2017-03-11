using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Evol.Domain.Commands;
using Evol.Domain.Configuration;

namespace Evol.Domain.Messaging
{
    public class DefaultCommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandlerActivator CommandHandlerActivator { get; set; }

        public DefaultCommandHandlerFactory()
        {
            CommandHandlerActivator = new DefaultCommandHandlerActivator();
        }

        public DefaultCommandHandlerFactory(ICommandHandlerActivator activator)
        {
            if (activator == null)
                throw new ArgumentNullException(nameof(activator));
            CommandHandlerActivator = activator;
        }

        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            return CommandHandlerActivator.Create<T>();
        }

        public class DefaultCommandHandlerActivator : ICommandHandlerActivator
        {
            //private readonly Func<IDependencyResolver> _resolverThunk;

            public DefaultCommandHandlerActivator()
            {
                //_resolverThunk = () => AppConfiguration.Current.DependencyConfiguration.DependencyResolver;
            }

            //public DefaultCommandHandlerActivator(IDependencyResolver resolver)
            //{
            //    if (resolver == null)
            //        throw new ArgumentNullException(nameof(resolver));
            //    _resolverThunk = () => resolver;
            //}

            public ICommandHandler<T> Create<T>() where T : Command
            {
                var result = AppConfiguration.Current.Container.Resolve<ICommandHandler<T>>();
                //var result = (ICommandHandler<T>)_resolverThunk().GetService(typeof(ICommandHandler<T>));
                if (result == null)
                    throw new NullReferenceException("未找到实现该接口的类，检查是否依赖注册：" + nameof(ICommandHandler<T>));
                return result;
            }
        }
    }
}
