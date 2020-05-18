using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consulting.Applications.AppService.FileManagement;
using Consulting.Applications.AppService.RoleManagement;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.FileUploadDto;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Applications.Notification;
using Consulting.Common.Auth;
using Consulting.Common.Constants;
using Consulting.Common.Model;
using Consulting.Common.Resources;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class AuthController : Controller
    {

        UserAppService userAppService;
        BranchAppService branchAppService;

        UploadAppService uploadAppService;
        AccessControlAppService accessControl;
        private NotificationAppService notificationAppService;

        public AuthController(UserAppService _userAppService, AccessControlAppService _accessControlAppService, UploadAppService _uploadAppService
            , NotificationAppService _notificationAppService, BranchAppService _branchAppService)
        {
            userAppService = _userAppService;
            accessControl = _accessControlAppService;
            uploadAppService = _uploadAppService;
            notificationAppService = _notificationAppService;
            branchAppService = _branchAppService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ResultObject> Login([FromBody] AuthParam authParam)
        {
            var branch = await branchAppService.GetBranchByBranchCodeAsync(authParam.BranchCode);
            ResultObject resultObject = new ResultObject();

            if (branch == null)
            {
                resultObject.Result = null;
                resultObject.ServerErrors.Add(new ServerErr() { Hint = ErrorMessages.NotFoundBranch, Type = ConstErrorTypes.BussinessError });
                return resultObject;
            }

            var userDto = await userAppService.FindUser(authParam.UserName, authParam.Password, branch.ID);

            if (userDto == null)
            {
                resultObject.Result = userDto;
                resultObject.ServerErrors.Add(new ServerErr() { Hint = ErrorMessages.NotuserFound });
                return resultObject;
            }
            AttachmentFilterDto filter = new AttachmentFilterDto()
            {
                UserID = userDto.ID,
                CategoryID = ConstAttachmentTypeCategory.User,
                pageNumber = 1
            };
            var userAttachments = await uploadAppService.GetAllAttachmentsAsync(filter);

            userDto.PicturePath = ((IEnumerable<AttachmentDto>)(userAttachments.Results))?.FirstOrDefault()?.Path;


            if (userDto.IsActive == false)
            {
                resultObject.Result = userDto;
                resultObject.ServerErrors.Add(new ServerErr() { Hint = ErrorMessages.UserNotEnable });
                return resultObject;
            }
            else if (userDto.UserBranch == null)
            {
                resultObject.Result = null;
                resultObject.ServerErrors.Add(new ServerErr() { Hint = ErrorMessages.NotAccessbranch, Type = ConstErrorTypes.BussinessError });
                return resultObject;
            }
            else if (!userDto.UserBranch.Branch.IsActive)
            {
                resultObject.Result = null;
                resultObject.ServerErrors.Add(new ServerErr() { Hint = "شعبه فعال نمی باشد.", Type = ConstErrorTypes.BussinessError });
                return resultObject;
            }
            if (userDto != null)
            {
                userDto.Token = JwtAuthManager.GenerateJWTToken(username: authParam.UserName, userID: userDto.ID);
                if (userDto.IsRequireChangePass)
                {
                    var changePassActivity = new ActivityDto()
                    {
                        Id = ConstActivities.changePassword,
                        ParentId = 2,
                        Name = "changePassword",
                        Title = "تغییر رمز",
                        Path = "/mp/changePassword",
                        IsMenu = true,
                        IsActive = true,
                        IconClass = "key",
                        Description = "شما ملزم به تغییر رمز عبور می باشید. لطفا رمز عبور را تغییر داده و دوباره به سیستم وارد شوید."
                    };
                    userDto.ActivityDtos.Add(changePassActivity);
                }
                else
                    userDto.ActivityDtos = await accessControl.GetActivitiesAsync(userDto.ID, userDto.UserBranch.BranchId, userDto.IsRequireChangePass);
            }

            //notificationAppService.SendMessage($"کاربر {userDto.UserName} {Environment.NewLine} ورود شما در تاریخ {DateConvertor.Instance.ConvertGregorianToPersianDate(DateTime.Now)} در سامانه صندوق های خرد محلی {userDto.UserBranch.BranchName} ثبت گردید ",
            //    userDto.PhoneNumber);



            return new ResultObject { Result = userDto, ServerErrors = null };
        }

        [HttpGet]
        [Route("GetActivitiesByRoleID")]
        public async Task<ResultListDto> GetActivitiesByRoleIDAsync(int roleID)
        {
            var activities = await accessControl.GetActivitiesByRoleIDAsync(roleID);
            return new ResultListDto { Results = activities };
        }


        [HttpGet]
        [Route("GetAllActivitiesHasAccess")]
        public async Task<ResultListDto> GetAllActivitiesHasAccessAsync(int roleID)
        {
            var activities = await accessControl.GetAllActivitiesHasAccessAsync(roleID);
            return new ResultListDto { Results = activities };
        }


        [HttpPost]
        [Route("AddAllActivitiesHasAccess")]
        public async Task<ResultListDto> AddAllActivitiesHasAccessAsync([FromBody] IEnumerable<ActivityRoleModelDto> activityRolelDto)
        {
            return await accessControl.AddActivitiesByRoleAsync(activityRolelDto);
        }

    }
}