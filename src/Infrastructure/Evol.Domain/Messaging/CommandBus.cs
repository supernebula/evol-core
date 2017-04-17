using System;
using System.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Evol.Domain.Commands;
using Evol.Domain.Uow;

namespace Evol.Domain.Messaging
{
    public class CommandBus : ICommandBus
    {
        public ICommandHandlerFactory CommandHandlerFactory { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        private IUnitOfWorkManager _unitOfWorkManager { get; set; }

        private ILoggerFactory _loggerFactory { get; set; }

        private ILogger _logger { get; set; }


        //public CommandBus(IUnitOfWork unitOfWork, ICommandHandlerFactory commandHandlerFactory)
        //{
        //    UnitOfWork = unitOfWork;
        //    CommandHandlerFactory = commandHandlerFactory;
        //}

        public CommandBus(IUnitOfWorkManager unitOfWorkManager, ICommandHandlerFactory commandHandlerFactory, ILoggerFactory loggerFactory)
        {
            //UnitOfWork = unitOfWork;
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
                await UnitOfWork.SaveChangesAsync();
                await UnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //log
                throw ex;
            }
            _logger.LogDebug("EXECUTE> UnitOfWork.CommitAsync()");
        }
    }
}
