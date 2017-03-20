using System;
using System.Threading.Tasks;

namespace Evol.Domain.Uow
{
    public class UnitOfWorkBuild
    {
        public UnitOfWorkBuild(UnitOfWorkOption option)
        {
            OptionArg = option;
        }

        public UnitOfWorkOption OptionArg { get; }

        public Func<IUnitOfWorkManager> UnitOfWorkManagerThunk = () => { throw new NotImplementedException(); };

        public static UnitOfWorkBuild UnitOfWork()
        {
            return new UnitOfWorkBuild(new UnitOfWorkOption());
        }

        public static UnitOfWorkBuild UnitOfWork(UnitOfWorkOption option)
        {
            return new UnitOfWorkBuild(option);
        }

        public async Task<TResult> RunAsync<TResult>(Func<TResult> func)
        {
            var uow = UnitOfWorkManagerThunk.Invoke().Begin(OptionArg);
            var result = func.Invoke();
            await uow.CommitAsync();
            return result;
        }

        public async Task RunAsync(Action action)
        {
            var uow = UnitOfWorkManagerThunk.Invoke().Begin(OptionArg);
            action.Invoke();
            await uow.CommitAsync();
        }
    }
}
