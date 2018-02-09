using System;
using Evol.Domain.Commands;
using Evol.Domain.Configuration;
using Evol.Configuration;

namespace Evol.Domain.Messaging
{
    public class DefaultCommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandlerActivator CommandHandlerActivator { get; set; }

        public DefaultCommandHandlerFactory()
        {
            CommandHandlerActivator = new DefaultCommandHandlerActivator();
        }

        //public DefaultCommandHandlerFactory(ICommandHandlerActivator activator)
        //{
        //    if (activator == null)
        //        throw new ArgumentNullException(nameof(activator));
        //    CommandHandlerActivator = activator;
        //}

        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            return CommandHandlerActivator.Create<T>();
        }

        public class DefaultCommandHandlerActivator : ICommandHandlerActivator
        {
            public DefaultCommandHandlerActivator()
            {
            }

            public ICommandHandler<T> Create<T>() where T : Command
            {
                var result = AppConfig.Current.IoCManager.GetService<ICommandHandler<T>>();
                if (result == null)
                    throw new NullReferenceException($"未找到实现该接口的类，检查是否依赖注册：{nameof(ICommandHandler<T>)}, 类型T定义:{typeof(T).FullName}");
                return result;
            }
        }
    }
}
