using Evol.Domain.Events;
using Evol.Domain.Messaging;
using Sample.Domain.Events;
using System.Threading.Tasks;

namespace Sample.Domain.EventHandlers
{
    public class UserEventHandler : IEventHandler<UserCreateEvent>
    {
        [ForkHandle]
        public Task HandleAsync(UserCreateEvent @event)
        {
            //用户创建后，发送邮件到用户邮箱
            //logic statment
            return Task.FromResult(1);
        }
    }
}
