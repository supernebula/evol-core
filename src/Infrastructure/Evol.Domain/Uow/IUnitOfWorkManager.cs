
namespace Evol.Domain.Uow
{
    public interface IUnitOfWorkManager
    {

        IActiveUnitOfWork Current { get; }


        IUnitOfWorkToComplete Begin();

        /// <summary>
        /// TransactionScopeOption, Waiting for .NetCore 2.0
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        //IUnitOfWorkToComplete Begin(TransactionScopeOption scope);


        IUnitOfWorkToComplete Begin(UnitOfWorkOption option);
    }
}
