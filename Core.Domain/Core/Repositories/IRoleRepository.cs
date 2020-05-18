using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
    public interface IRoleRepository: IRepository<Role>
    {       
        Role GetMyRole();
        Task<Role> GetMyRoleAsync();
        //Task<List<UserRoles>> GetRoleActivitiesAsync(int roleId);
    }
}
