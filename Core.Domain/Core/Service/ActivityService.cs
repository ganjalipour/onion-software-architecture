using Consulting.Common.Data;
using Consulting.Domains.Core.Core.Service;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Service
{
    public class ActivityService
    {

        private IActivityRepositoy activityRepositoy;
        public ActivityService(IActivityRepositoy _activityRepositoy)
        {
            activityRepositoy = _activityRepositoy;
        }

        public async Task<ICollection<Activity>> GetActivitiesAsync(int userID, int branchID, bool isRequireChangePass)
        {
            return await activityRepositoy.GetActivitiesAsync(userID, branchID, isRequireChangePass);
        }

        public async Task<bool> UserHasAccessAsync(int userID, int activityID)
        {
            return await activityRepositoy.UserHasAccessAsync(userID, activityID);
        }
        public async Task<IEnumerable<Activity>> GetActivitiesByRoleIDAsync(int roleID)
        {
            return await activityRepositoy.GetActivitiesByRoleIDAsync(roleID);
        }

        public async Task<IEnumerable<ActivityRoleModel>> GetAllActivitiesHasAccessAsync(int roleID)
        {
          return  await activityRepositoy.GetAllActivitiesHasAccessAsync(roleID);
        }

        public async Task AddActivitiesByRoleAsync(IList<RoleActivity> activityRoleList)
        {
            await activityRepositoy.SetAllActivitiesHasAccessAsync(activityRoleList);
        }
    }
}
