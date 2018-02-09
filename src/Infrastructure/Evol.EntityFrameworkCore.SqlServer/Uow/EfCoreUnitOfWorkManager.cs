using Evol.Common.Logging;
using Evol.Common.IoC;
using Evol.UnitOfWork.Abstractions;
using System;

namespace Evol.EntityFrameworkCore.SqlServer.Uow
{
    public class EfCoreUnitOfWorkManager : IUnitOfWorkManager
    {
        public Guid Key { get; private set; }

        private IIoCManager _ioCManager { get; set; }

        public EfCoreUnitOfWorkManager(IIoCManager ioCManager, ILoggerFactory logger)
        {
            _ioCManager = ioCManager;
            logger.CreateLogger<EfCoreUnitOfWorkManager>().LogDebug("CONSTRUCT> EfUnitOfWorkManager");
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
            //// 生命周期变更：由每请求唯一工作单元 修改为 每依赖工作单元 20180102
            //if (_current != null)
            //    return _current;
            //_current = _ioCManager.GetService<IUnitOfWork>();
            //return _current;

            var uow = _ioCManager.GetService<IUnitOfWork>();
            if (_current == null)
            {
                _current = uow;
                return _current;
            }

            if (_current == uow)
                return _current;


            _current.Child = uow;
            uow.Parent = _current;
            //设置当前工作单元
            _current = uow;
            return _current;
        }
    }
}
