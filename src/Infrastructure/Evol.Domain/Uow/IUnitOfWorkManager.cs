
namespace Evol.Domain.Uow
{
    public interface IUnitOfWorkManager
    {

        IActiveUnitOfWork Current { get; }


        IUnitOfWorkToComplete Begin();


        IUnitOfWorkToComplete Begin(UnitOfWorkOption option);
    }
}
