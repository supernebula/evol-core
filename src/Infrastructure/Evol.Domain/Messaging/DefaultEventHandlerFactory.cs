using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Evol.Domain.Events;
using Evol.Domain.Configuration;

namespace Evol.Domain.Messaging
{
    public class DefaultEventHandlerFactory : IEventHandlerFactory
    {
        public IEventHandlerActivator EventHandlerActivator { get; set; }

        public DefaultEventHandlerFactory()
        {
            EventHandlerActivator = new DefaultEventHandlerActivator();
        }

        public DefaultEventHandlerFactory(IEventHandlerActivator activator)
        {
            if (activator == null)
                throw new ArgumentNullException(nameof(activator));
            EventHandlerActivator = activator;
        }

        public IEnumerable<IEventHandler<T>> GetHandler<T>() where T : Event
        {
            return EventHandlerActivator.Create<T>();
        }

        public class DefaultEventHandlerActivator : IEventHandlerActivator
        {
            //private readonly Func<IDependencyResolver> _resolverThunk;

            //public DefaultEventHandlerActivator()
            //{
            //    _resolverThunk = () => AppConfiguration.Current.DependencyConfiguration.DependencyResolver;
            //}

            //public DefaultEventHandlerActivator(IDependencyResolver resolver)
            //{
            //    if (resolver == null)
            //        throw new ArgumentNullException(nameof(resolver));
            //    _resolverThunk = () => resolver;
            //}

            public IEnumerable<IEventHandler<T>> Create<T>() where T : Event
            {
                var result = AppConfiguration.Current.Container.ResolveAll<IEventHandler<T>>(new ResolverOverride[0]);
                return result;
            }
        }
    }
}
