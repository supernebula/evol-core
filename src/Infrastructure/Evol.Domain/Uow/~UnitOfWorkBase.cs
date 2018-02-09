//using System;
//using System.Threading.Tasks;

//namespace Evol.Domain.Uow
//{
//    public abstract class UnitOfWorkBase : IUnitOfWork ,IDisposable
//    {
//        public Guid Key { get; protected set; }

//        public IUnitOfWork Parent { get; set; }

//        public IUnitOfWork Child { get; set; }

//        public UnitOfWorkOption Option { get; private set; }

//        public bool IsDisposed { get; private set; }

//        public event EventHandler Committed;

//        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;

//        public event EventHandler Disposed;

//        private bool _isBeginCalledBefore;

//        private bool _successed;
//        protected abstract void BeginUow();

//        public void Begin(UnitOfWorkOption option)
//        {
//            if (_isBeginCalledBefore)
//                return;
//            Option = option;
//            BeginUow();
//            _isBeginCalledBefore = true;
//        }

//        public void Begin()
//        {
//            Begin(new UnitOfWorkOption());
//        }

//        protected abstract Task CommitUowAsync();

//        public async Task CommitAsync()
//        {
//            try
//            {
//                await CommitUowAsync();
//                _successed = true;
//                OnCommitted();
//            }
//            catch (Exception ex)
//            {
//                _exception = ex;
//                throw ex;
//            }

//        }

//        public abstract void Rollback();

//        public virtual void Dispose()
//        {
//            if (!_isBeginCalledBefore || IsDisposed)
//                return;
//            IsDisposed = true;

//            if (!_successed)
//                OnFailed(_exception);

//            OnDisposed();
//        }



//        private Exception _exception;

//        protected virtual void OnCommitted()
//        {
//            if (Committed == null)
//                return;
//            Committed.Invoke(this, new EventArgs());
//        }

//        protected virtual void OnFailed(Exception ex)
//        {
//            if (Failed == null)
//                return;
//            Failed.Invoke(this, new UnitOfWorkFailedEventArgs(ex));
//        }

//        protected virtual void OnDisposed()
//        {
//            if (Disposed == null)
//                return;
//            Disposed.Invoke(this, new EventArgs());
//        }

//        public abstract TDbContext GetDbContext<TDbContext>() where TDbContext : class;

//        public abstract void AddDbContext<TDbContext>(TDbContext dbContext) where TDbContext : class;
//    }


//}
