

namespace Evol.Domain.Uow
{
    /// <summary>
    /// Temporarily does not support distributed transactions. Will be implemented in .netcore version 2.0
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork
    {
        string Id { get; }

        IUnitOfWork Outer { get; set; }

        void Begin(UnitOfWorkOption option);

        void Begin();


    }
}
