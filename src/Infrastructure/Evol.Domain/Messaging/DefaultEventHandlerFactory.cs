using System;
using System.Collections.Generic;
using Evol.Domain.Events;
using Evol.Domain.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain.Messaging
{
    public class DefaultEventHandlerFactory : IEventHandlerFactory
    {
        public IEventHandlerActivator EventHandlerActivator { get; set; }

        public DefaultEventHandlerFactory()
        {
            EventHandlerActivator = new DefaultEventHandlerActivator();
        }

        //public DefaultEventHandlerFactory(IEventHandlerActivator activator)
        //{
        //    if (activator == null)
        //        throw new ArgumentNullException(nameof(activator));
        //    EventHandlerActivator = activator;
        //}

        public IEnumerable<IEventHandler<T>> GetHandler<T>() where T : Event
        {
            return EventHandlerActivator.Create<T>();
        }

        public class DefaultEventHandlerActivator : IEventHandlerActivator
        {

            public IEnumerable<IEventHandler<T>> Create<T>() where T : Event
            {

                var result = AppConfig.Current.IoCManager.GetServices<IEventHandler<T>>();
                if (result == null)
                    throw new NullReferenceException($"未找到实现该接口的类，检查是否依赖注册：{nameof(IEventHandler<T>)}, 类型T定义:{typeof(T).FullName}");
                return result;
            }
        }
    }
}
