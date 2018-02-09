using System;

namespace Evol.UnitOfWork.Abstractions
{
    /// <summary>
    /// Temporarily does not support distributed transactions. Will be implemented in .netcore version 2.0
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork
    {
        Guid Key { get; }

        IUnitOfWork Parent { get; set; }

        IUnitOfWork Child { get; set; }

        void Begin(UnitOfWorkOption option);


        void Begin();

        void Rollback();


    }
}
