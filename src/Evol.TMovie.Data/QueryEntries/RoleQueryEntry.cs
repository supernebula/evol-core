using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.QueryEntries;

using Evol.TMovie.Domain.Repositories;


namespace Evol.TMovie.Data.QueryEntries
{
    public class RoleQueryEntry : IRoleQueryEntry
    {
        private IRoleRepository _roleRepository { get; set; }
        public RoleQueryEntry(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> FetchAsync(Guid id)
        {
            return await _roleRepository.FindAsync(id);
        }

        public async Task<List<Role>> RetrieveAsync(RoleQueryParameter param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Code == null || param.Name == null)
                throw new ArgumentNullException(($"{nameof(param.Code)} & {nameof(param.Name)}"));

            Expression<Func<Role, bool>> query = null;
            if (param.Code != null && param.Name != null)
                query = e => e.Code.StartsWith(param.Code) && e.Name.StartsWith(param.Name);
            else if (param.Code != null)
                query = e => e.Code.StartsWith(param.Code);
            else if (param.Name != null)
                query = e => e.Name.StartsWith(param.Name);

            var list = (await _roleRepository.RetrieveAsync(query)).ToList();
            return list;
        }

        public async Task<IPaged<Role>> PagedAsync(RoleQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Code == null || param.Name == null)
                throw new ArgumentNullException(($"{nameof(param.Code)} & {nameof(param.Name)}"));

            Expression<Func<Role, bool>> query = null;
            if (param.Code != null && param.Name != null)
                query = e => e.Code.StartsWith(param.Code) && e.Name.StartsWith(param.Name);
            else if (param.Code != null)
                query = e => e.Code.StartsWith(param.Code);
            else if (param.Name != null)
                query = e => e.Name.StartsWith(param.Name);

            return await _roleRepository.PagedAsync(query, pageIndex, pageSize);
        }

        public async Task<List<Role>> GetByIdsAsync(Guid[] ids)
        {
            return (await _roleRepository.RetrieveAsync(e => ids.Contains(e.Id))).ToList();
        }
    }
}
