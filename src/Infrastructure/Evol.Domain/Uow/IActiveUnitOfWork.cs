using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Domain.Uow
{
    public interface IActiveUnitOfWork : IUnitOfWorkToComplete
    {
        UnitOfWorkOption Option { get; }

        Task SaveChangesAsync();


        TDbContext GetDbContext<TDbContext>() where TDbContext : class;


        void AddDbContext<TDbContext>(TDbContext dbContext) where TDbContext : class;

        bool IsDisposed { get; }

        event EventHandler Committed;

        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        event EventHandler Disposed;
    }
}
