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

        public IUnitOfWorkManager UnitOfWorkManager { get; }

        public static UnitOfWorkBuild UseOption()
        {
            return new UnitOfWorkBuild(new UnitOfWorkOption());
        }

        public static UnitOfWorkBuild UseOption(UnitOfWorkOption option)
        {
            return new UnitOfWorkBuild(option);
        }

        public async Task<TResult> RunAsync<TResult>(Func<TResult> func)
        {
            var uow = UnitOfWorkManager.Begin(OptionArg);
            var result = func.Invoke();
            await uow.CompleteAsync();
            return result;
        }

        public async Task RunAsync(Action action)
        {
            var uow = UnitOfWorkManager.Begin(OptionArg);
            action.Invoke();
            await uow.CompleteAsync();
        }
    }
}
