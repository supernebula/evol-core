using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Evol.Domain.Uow
{
    public class UnitOfWorkOption
    {
        public TimeSpan? Timeout { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }

        //public System.Transactions.TransactionScopeOption TransactionScope { get; set; }
    }
}
