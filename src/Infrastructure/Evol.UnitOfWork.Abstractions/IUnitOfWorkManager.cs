using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.UnitOfWork.Abstractions
{
    /// <summary>
    /// 依赖注入时，生命周期必须是： InstancePerRequest
    /// </summary>
    public interface IActiveUnitOfWorkManager
    {
        Guid Key { get; }

        IActiveUnitOfWork Current { get; }
    }

    /// <summary>
    /// 依赖注入时，生命周期必须是： InstancePerRequest
    /// </summary>
    public interface IUnitOfWorkManager : IActiveUnitOfWorkManager
    {
        IUnitOfWork Build();
    }
}
