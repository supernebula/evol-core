
namespace Evol.UnitOfWork.Abstractions
{
    public interface IMultiUnitOfWorkManager
    {

        IUnitOfWork Current { get; }


        IUnitOfWorkToComplete Begin();


        IUnitOfWorkToComplete Begin(UnitOfWorkOption option);
    }
}
