using Consulting.Common.Data;
using Consulting.Domains.Core.Core.Service;
using Consulting.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
    public interface IActivityRepositoy : IRepository<Activity>
    {
        Task<bool> UserHasAccessAsync(int userID, int activityID);
        Task<ICollection<Activity>> GetActivitiesAsync(int userID, int branchID, bool isRequireChangePass);
        Task<IEnumerable<Activity>> GetActivitiesByRoleIDAsync(int roleID);
        Task<IEnumerable<ActivityRoleModel>> GetAllActivitiesHasAccessAsync(int roleID);
        Task SetAllActivitiesHasAccessAsync(IList<RoleActivity> activityRoleList);
    }
}