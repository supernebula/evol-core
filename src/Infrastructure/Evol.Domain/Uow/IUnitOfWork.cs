

namespace Evol.Domain.Uow
{

    public interface IUnitOfWork : IActiveUnitOfWork
    {
        string Id { get; }

        IUnitOfWork Outer { get; set; }

        void Begin(UnitOfWorkOption option);
    }
}
