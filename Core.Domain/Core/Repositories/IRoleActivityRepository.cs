using Consulting.Common.Data;
using Consulting.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
   public interface IRoleActivityRepository : IRepository<RoleActivity>
    {
        Task<IEnumerable<RoleActivity>> GetRoleActivitiesAsync(int id);
        Task<RoleActivity> GetRoleActivityAsync(int id);
    }
}
