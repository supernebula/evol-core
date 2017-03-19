using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Domain.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        public string Id { get; }
        public IUnitOfWork Outer { get; set; }

        public UnitOfWorkOption Option { get; private set; }

        public bool IsDisposed { get; private set; }

        public void Begin(UnitOfWorkOption option)
        {
            Option = option;
        }

        public abstract Task SaveChangesAsync(); 


        protected abstract Task CommitUowAsync();

        public async Task CommitAsync()
        {
            await CommitUowAsync();
        }

        public abstract void Dispose();


    }
}
