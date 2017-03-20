using System;
using System.Threading.Tasks;

namespace Evol.Domain.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork ,IDisposable
    {
        public string Id { get; }
        public IUnitOfWork Outer { get; set; }

        public UnitOfWorkOption Option { get; private set; }

        public bool IsDisposed { get; private set; }

        public event EventHandler Committed;

        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        public event EventHandler Disposed;

        protected UnitOfWorkBase(UnitOfWorkOption option)
        {
            Option = option;
        }

        protected abstract void BeginUow();

        public void Begin()
        {
            BeginUow();
            _isBeginCalledBefore = true;
        }

        public abstract Task SaveChangesAsync(); 


        protected abstract Task CommitUowAsync();

        public async Task CommitAsync()
        {

            try
            {
                await CommitUowAsync();
                _successed = true;
                OnCommitted();
            }
            catch (Exception ex)
            {
                _exception = ex;
                throw;
            }

        }

        public virtual void Dispose()
        {
            if (!_isBeginCalledBefore || IsDisposed)
                return;
            IsDisposed = true;

            if (!_successed)
                OnFailed(_exception);

            OnDisposed();
        }

        private bool _isBeginCalledBefore;

        private bool _successed;

        private Exception _exception;

        protected virtual void OnCommitted()
        {
            Committed.Invoke(this, new EventArgs());
        }

        protected virtual void OnFailed(Exception ex)
        {
            Failed.Invoke(this, new UnitOfWorkFailedEventArgs(ex));
        }

        protected virtual void OnDisposed()
        {
            Disposed.Invoke(this, new EventArgs());
        }

        public abstract TDbContext GetDbContext<TDbContext>() where TDbContext : class;

        public abstract void AddDbContext<TDbContext>(string name, TDbContext dbContext) where TDbContext : class;
    }


}
