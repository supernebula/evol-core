using Evol.Domain;
using Evol.Domain.Uow;
using Evol.EntityFramework.Uow;
using Microsoft.EntityFrameworkCore;
using System;

namespace Evol.EntityFramework.Repository
{
    public class EfUnitOfWorkDbContextProvider : IEfDbContextProvider
    {
        public IActiveUnitOfWork UnitOfWork
        {
            get;
            set;
        }

        public EfUnitOfWorkDbContextProvider(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            var context = UnitOfWork.GetDbContext<TDbContext>();
            if (context != null)
                return context;
            context = AppConfig.Current.IoCManager.GetService<TDbContext>();
            UnitOfWork.AddDbContext(context);
            return context;
        }
    }
}
