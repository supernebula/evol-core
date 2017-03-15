using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Web.Identity
{
    public class RoleStore<TRole> :
        IQueryableRoleStore<TRole>,
        IRoleClaimStore<TRole><TRole>,
        IRoleStore<TRole><TRole>,
        IRoleValidator<TRole><TRole>

    {

    }
}
