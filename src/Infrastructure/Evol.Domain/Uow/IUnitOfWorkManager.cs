
namespace Evol.Domain.Uow
{
    public interface IUnitOfWorkManager
    {

        IUnitOfWork Current { get; }


        IUnitOfWorkToComplete Begin();


        IUnitOfWorkToComplete Begin(UnitOfWorkOption option);
    }
}
