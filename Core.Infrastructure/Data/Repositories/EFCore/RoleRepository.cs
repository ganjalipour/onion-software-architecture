using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Data.Repositories.EFCore
{
    public class RoleRepository : EFCoreRepository<Role>, IRoleRepository
    {
     //   private AppDBContext Context { set; get; }
        public RoleRepository(IContextProviderFactory contextProvider) : base(contextProvider)
        {
         //   Context = context;
        }

        public Role GetMyRole()
        {
            var role = Context.Roles.FirstOrDefault();
            return role;
        }

        public async Task<Role> GetMyRoleAsync()
        {
            return await Context.Roles.FirstOrDefaultAsync<Role>();          
        }
        public void AddRole(string name)
        {
            Context.Roles.Add(new Role() { RoleName = name });
        }

    }
}
