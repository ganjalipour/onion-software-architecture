using Consulting.Common.Constants;
using Consulting.Domains.Core.Core.Service;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class ActivityRepositoy : EFCoreRepository<Activity>, IActivityRepositoy
    {
        public ActivityRepositoy(IContextProviderFactory  contextProvider) : base(contextProvider)
        {
        }

        public Activity GetActivities()
        {
            return Context.Activities.FirstOrDefault();
        }

        public async Task<ICollection<Activity>> GetActivitiesAsync(int userID, int branchID, bool isRequireChangePass)
        {
            return await
            (
                from roleactivity in Context.RoleActivities
                join activity in Context.Activities on roleactivity.ActivityID equals activity.Id
                join userBranchRole in Context.UserBranchRoles on roleactivity.RoleID equals userBranchRole.RoleId 
                join userbranch in Context.UserBranches on userBranchRole.UserId equals userbranch.UserId 
                where userBranchRole.UserId == userID && userBranchRole.BranchId == branchID && userbranch.BranchId == branchID
                //&& (!isRequireChangePass || (isRequireChangePass && activity.Id == ConstActivities.changePassword))
                select new Activity
                {
                    Id = roleactivity.ActivityID,
                    Path = activity.Path,
                    Name = activity.Name,
                    IsActive = activity.IsActive,
                    IsMenu = activity.IsMenu,
                    Order = activity.Order,
                    ParentId = activity.ParentId,
                    Code = activity.Code,
                    IconClass = activity.IconClass,
                    Title = activity.Title,
                    Description = activity.Description
                }
            ).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetActivitiesByRoleIDAsync(int roleID)
        {
            return await
            (
                from roleactivity in Context.RoleActivities
                join activity in Context.Activities on roleactivity.ActivityID equals activity.Id
                join userBranchRole in Context.UserBranchRoles on roleactivity.RoleID equals userBranchRole.RoleId
                join userbranch in Context.UserBranches on userBranchRole.UserId equals userbranch.UserId     
                where userBranchRole.RoleId == roleID && userbranch.BranchId == userBranchRole.BranchId
                select new Activity
                {
                    Id = roleactivity.ActivityID,
                    Path = activity.Path,
                    Name = activity.Name,
                    IsActive = activity.IsActive,
                    IsMenu = activity.IsMenu,
                    Order = activity.Order,
                    ParentId = activity.ParentId,
                    Code = activity.Code,
                    IconClass = activity.IconClass,
                    Title = activity.Title,
                    Description = activity.Description
                }
            ).ToListAsync();
        }

        public async Task<IEnumerable<ActivityRoleModel>> GetAllActivitiesHasAccessAsync(int roleID)
        {
            //var roleActivities = (
            //         from activity in Context.Activities
            //         join roleActivity in Context.RoleActivities on activity.Id equals roleActivity.ActivityID into gg

            //         from entity in gg.DefaultIfEmpty()
            //         select new ActivityRoleModel()
            //         {
            //             ActivityID = activity.Id,
            //             RoleID = entity.RoleID,
            //             RoleActivitiyID = entity.ID
            //         }
            //     ).Where(p=>p.RoleID == roleID).ToList();

            var roleActivities = from ra in Context.RoleActivities
                                 where ra.RoleID == roleID
                                 select ra;
            var ActivivyRole = await (from activity in Context.Activities
                                      join roleActivity in roleActivities on activity.Id equals roleActivity.ActivityID into gg
                                      from entity in gg.DefaultIfEmpty()
                                      select new ActivityRoleModel()
                                      {
                                          ActivityID = activity.Id,
                                          RoleID = roleID,
                                          Title = activity.Title,
                                          HasAccess = entity.RoleID == roleID ? true : false
                                      }).ToListAsync();

            return ActivivyRole;

        }
 

        public async Task<bool> UserHasAccessAsync(int userID,int activityID)
        {
            var activities = await
            (
                from roleactivity in Context.RoleActivities
                join userrole in Context.UserBranchRoles on roleactivity.RoleID equals userrole.RoleId
                join userbranch in Context.UserBranches on userrole.UserId equals userbranch.UserId
                where userbranch.UserId == userID && roleactivity.ActivityID == activityID
                select new
                {
                    ActivityID = roleactivity.ActivityID
                }
            ).ToListAsync();

            if (activities.Count > 0) return true;
            return false;
        }

        public async Task SetAllActivitiesHasAccessAsync(IList<RoleActivity> activityRoleList)
        {
            var roleID = activityRoleList[0].RoleID;
            var roleActivities = await Context.RoleActivities.Where(p => p.RoleID == roleID).ToListAsync();
            var addedRoleSet = activityRoleList.Except(roleActivities);
            var removedRoleSet = roleActivities.Except(activityRoleList);
            Context.RemoveRange(removedRoleSet);
            await Context.AddRangeAsync(addedRoleSet);
        }
    }
}
