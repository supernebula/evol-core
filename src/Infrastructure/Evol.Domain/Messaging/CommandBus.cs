using System;
using System.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Evol.Domain.Commands;
using Evol.Domain.Uow;
using System.Linq;

namespace Evol.Domain.Messaging
{
    public class CommandBus : ICommandBus
    {
        public ICommandHandlerFactory CommandHandlerFactory { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        private IUnitOfWorkManager _unitOfWorkManager { get; set; }

        private ILoggerFactory _loggerFactory { get; set; }

        private ILogger _logger { get; set; }

        public CommandBus(IUnitOfWorkManager unitOfWorkManager, ICommandHandlerFactory commandHandlerFactory, ILoggerFactory loggerFactory)
        {
            _unitOfWorkManager = unitOfWorkManager;
            CommandHandlerFactory = commandHandlerFactory;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<CommandBus>();
        }

        public async Task SendAsync<T>(T command) where T : Command
        {
            UnitOfWork = _unitOfWorkManager.Build();
            _logger.LogDebug("EXECUTE> _unitOfWorkManager.Build()");
            var commandHandler = CommandHandlerFactory.GetHandler<T>();
            try
            {
                UnitOfWork.Begin(new UnitOfWorkOption() { IsolationLevel = IsolationLevel.ReadCommitted });
                await commandHandler.ExecuteAsync(command);
                await UnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //log
                throw ex;
            }

            ////处理事件，保证最终一致性
            //if (command.Events != null && command.Events.Any())
            //{
            //    var eventPublisher = AppConfig.Current.IoCManager.GetService<IEventPublisher>();
            //    await eventPublisher.PublishAsync(command.Events);
            //}

            _logger.LogDebug("EXECUTE> UnitOfWork.CommitAsync()");
        }
    }
}
