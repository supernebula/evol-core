﻿using Evol.Domain.Uow;
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

        public EfUnitOfWorkDbContextProvider(IActiveUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        public TDbContext Get<TDbContext>() where TDbContext : NamedDbContext
        {
            var context = UnitOfWork.GetDbContext<TDbContext>();
            if (context != null)
                return context;
            context = Activator.CreateInstance<TDbContext>();
            UnitOfWork.AddDbContext(context.Name, context);
            return context;
        }
    }
}
