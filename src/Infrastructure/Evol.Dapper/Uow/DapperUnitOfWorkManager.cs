using Evol.UnitOfWork.Abstractions;
using System;
using Evol.Common.IoC;
using Evol.Common.Logging;

namespace Evol.Dapper.Uow
{
    public class DapperUnitOfWorkManager : IUnitOfWorkManager
    {
        public Guid Key { get; }

        private IIoCManager IoCManager { get; set; }

        public DapperUnitOfWorkManager(IIoCManager ioCManager, ILoggerFactory logger)
        {
            IoCManager = ioCManager;
            logger.CreateLogger<DapperUnitOfWorkManager>().LogDebug("CONSTRUCT> DapperUnitOfWorkManager");
            Key = Guid.NewGuid();
        }

        public IUnitOfWork _current;
        public IActiveUnitOfWork Current
        {
            get
            {
                return _current;
            }
        }



        public IUnitOfWork Build()
        {
            ////生命周期变更：由每请求唯一工作单元 修改为 每依赖工作单元 20180102
            //if (_current != null)
            //    return _current;
            //_current = IoCManager.GetService<IUnitOfWork>();
            //return _current;

            var uow = IoCManager.GetService<IUnitOfWork>();
            if (_current == null)
            {
                _current = uow;
                return _current;
            }

            if (_current == uow)
                return _current;

            _current.Child = uow;
            uow.Parent = _current;
            return uow;
        }
    }
}
