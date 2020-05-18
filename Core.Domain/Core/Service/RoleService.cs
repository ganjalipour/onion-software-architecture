using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Service
{
    public class RoleService
    {

        private IRoleRepository roleRepository;
        public RoleService(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
        }

        public async Task CreateRoleAsync(Role Role)
        {
            await roleRepository.AddAsync(Role);
        }

        public Role GetMyRole()
        {
            return roleRepository.GetMyRole();
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            return await roleRepository.FindByFirstOrDefaultAsync(item => item.ID == id);
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await roleRepository.GetByPredicateAsync(null);
        }

        public async Task<Role> UpdateRoleAsync(Role Role)
        {
            return await roleRepository.UpdateAsync(Role, Role.ID);
        }

        public async Task RemoveRoleAsync(Role Role)
        {
          await roleRepository.RemoveAsync(Role.ID);
        }

    }
}
