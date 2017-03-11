
namespace Evol.Common.Repository
{
    public interface IUnitOfWorkOptions
    {
        System.Data.IsolationLevel? IsolationLevel { get; set; }

        bool IsTransactional { get; set; }

        System.Transactions.TransactionScopeOption TransactionScope { get; set; }
    }
}
