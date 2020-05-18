using AutoMapper;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Common.Constants;
using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Applications.AppService.RoleManagement
{
    public class AccessControlAppService
    {
        private ITransactionManager transactionManager;
        private readonly IMapper mapper;
        public ActivityService ActivityService;

        public AccessControlAppService( ActivityService _activityService, ITransactionManager _transactionManager, IMapper _mapper)
        {
            ActivityService = _activityService;
            mapper = _mapper;
            transactionManager = _transactionManager;

        }

        public async Task<bool> CheckAccess(int userID, int activityID)
        {
            return  await ActivityService.UserHasAccessAsync(userID,activityID);
        }

        public async Task<ICollection<ActivityDto>> GetActivitiesAsync(int userID, int branchID, bool isRequireChangePass)
        {          
            ICollection<Activity> activities = await ActivityService.GetActivitiesAsync(userID, branchID, isRequireChangePass);
            var actvityDtoList = mapper.Map<ICollection<ActivityDto>>(activities);
            return actvityDtoList;
        }

        public async Task<IEnumerable<ActivityDto>> GetActivitiesByRoleIDAsync(int roleID)
        {
            IEnumerable<Activity> activities = await ActivityService.GetActivitiesByRoleIDAsync(roleID);
            var actvityDtoList = mapper.Map<IEnumerable<ActivityDto>>(activities);
            return actvityDtoList;
        }

        public async Task<IEnumerable<ActivityRoleModelDto>> GetAllActivitiesHasAccessAsync(int roleID)
        {
            var activities = await ActivityService.GetAllActivitiesHasAccessAsync(roleID);
            var actvityDtoList = mapper.Map<IEnumerable<ActivityRoleModelDto>>(activities);
            return actvityDtoList;
        }

        public async Task<ResultListDto> AddActivitiesByRoleAsync(IEnumerable<ActivityRoleModelDto> activityRolelDto)
        {
            IList<RoleActivity> activityRoles = new List<RoleActivity>();
            foreach ( var item in activityRolelDto)
            {
                if (item.HasAccess)
                    activityRoles.Add(new RoleActivity() {  ActivityID= item.ActivityID, RoleID = item.RoleID });
            }
            await ActivityService.AddActivitiesByRoleAsync(activityRoles);
            await transactionManager.SaveAllAsync();
            return new ResultListDto() {  Results = true, MaxPageRows = 10, TotalRows = activityRoles.Count };
        }

    }
}
