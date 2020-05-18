using System;
using System.Threading.Tasks;
using Consulting.Applications.AppService.RoleManagement;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserAppService userAppService;
        public UserController(UserAppService _userAppService)
        {
            userAppService = _userAppService;
        }

        #region UserServices
        [HttpGet]
        [Route("getUser/{id}")]
 
        public async Task<ResultObject> GetAsync(int id)
        {
            var userdto = await userAppService.GetUserByID(id);
            return new ResultObject { Result = userdto, ServerErrors = null };
        }


        [HttpPost]
        [Route("getUsers")]   
        public async Task<ResultListDto> GetUsersAsync([FromBody] UserFilterDto userFilterDto = null)
        {
            ResultListDto userListdto = await userAppService.GetUsersAsync(userFilterDto);
            return userListdto;
        }

        [HttpPost]
        [Route("setUser")]
        public async Task<ResultObject> SetAsync([FromBody] UserDto userDto)
        {
            if (userDto.ID == 0)
               return await userAppService.CreateUserAsync(userDto);
            else
                return await userAppService.UpdateUserAsync(userDto);
        }


        [HttpPost]
        [Route("changePassword")]
        public async Task<ResultObject> ChangePasswordAsync([FromBody] PasswordDto passwordDto)
        {
            return await userAppService.ChangePasswordAsync(passwordDto);
        }

        [HttpPost]
        [Route("deleteUser/{id}")]
        public async Task<ResultObject> DeleteAsync(int id)
        {
            try
            {
                await userAppService.DeleteUserAsync(new UserDto { ID = id });
                return new ResultObject { Result = true, ServerErrors = null };
            }
            catch (Exception ex)
            {
                return new ResultObject { Result = false, ServerErrors = new[] { new ServerErr() { Hint = ex.Message, Type = "Err on Delete" } } };
            }
        }


        [HttpPost]
        [Route("recoverPass")]
        public async Task<ResultObject> ReCoverPassAsync([FromBody] RecoverPassDto recoverPassDto)
        {
            return await userAppService.ReCoverPassAsync(recoverPassDto);
        }


        [HttpPost]
        [Route("confirmRecoverPass")]
        public async Task<ResultObject> ConfirmRecoverPass([FromBody] RecoverPassDto recoverPassDto)
        {
            return await userAppService.ConfirmRecoverPass(recoverPassDto);
        }


        #endregion #region UserServices

        #region UserRolesServices
        [HttpGet]
        [Route("GetUserBranchRoles")]
        public async Task<ResultListDto> GetUserBranchRolesAsync(int userID, int branchID)
        {
            return await userAppService.GetUserRolesAsync(userID, branchID);
        }


        [Route("GetUserRoleInfo")]
        public async Task<ResultList> GetUserRoleInfoAsync([FromBody] UserBranchRoleDto userBranchRoleDto) {
            return await userAppService.GetUserRoleInfoAsync(userBranchRoleDto);
        }

        [Route("GetUserRoles")]
        public async Task<ResultList> GetUserRoles([FromBody] UserBranchRoleDto userBranchRoleDto)
        {
            return await userAppService.GetUserRolesAsync(userBranchRoleDto);
        }

        [HttpPost]
        [Route("SetUserBranchRole")]
        public async Task<ResultObject> SetUserBranchRolesAsync([FromBody] UserBranchRoleDto userRoleDto)
        {
            if (userRoleDto.ID == 0)
                return await userAppService.CreateUserRoleAsync(userRoleDto);
            else
                return await userAppService.UpdateUserRoleAsync(userRoleDto);
        }

        [HttpPost]
        [Route("deleteUserBranchRole/{id}")]
        public async Task<ResultObject> DeleteuserBranchRoleAsync(int id)
        {
            try
            {
                await userAppService.DeleteUserRoleAsync(new UserBranchRoleDto { ID = id });
                return new ResultObject { Result = true, ServerErrors = null };
            }
            catch (Exception ex)
            {

                return new ResultObject { Result = false, ServerErrors = new[] { new ServerErr() { Hint = ex.Message, Type = "Err on Delete" } } };
            }
        }
        #endregion UserRolesServices

        #region UserBranchServices

        [HttpGet]
        [Route("GetUserBranches/{id}")]
        public async Task<ResultListDto> GetUserBranchesAsync(int id)
        {
            return await userAppService.GetUserBranchesAsync(id);
        }

        [HttpGet]
        [Route("GetUserBranch/{id}")]
        public async Task<ResultObject> GetUserBranchAsync(int id)
        {
            var userBranchdto = await userAppService.GetUserBrancheAsync(id);
            return new ResultObject { Result = userBranchdto, ServerErrors = null };
        }


        [HttpPost]
        [Route("SetUserBranch")]
        public async Task<ResultObject> SetUserBranchesAsync([FromBody] UserBranchesDto userBranchesDto)
        {
            if (userBranchesDto.ID == 0)
                return await userAppService.CreateUserBranchesAsync(userBranchesDto);
            else
                return await userAppService.UpdateUserBranchesAsync(userBranchesDto);

        }

        [HttpPost]
        [Route("deleteUserBranch/{id}")]
        public async Task<ResultObject> DeleteUserBranchAsync(int id)
        {
            try
            {
                await userAppService.DeleteUserBrancheAsync(new UserBranchesDto { ID = id });
                return new ResultObject { Result = true, ServerErrors = null };
            }
            catch (Exception ex)
            {

                return new ResultObject { Result = false, ServerErrors = new[] { new ServerErr() { Hint = ex.Message, Type = "Err on Delete" } } };
            }
        }
        #endregion UserBranchServices

    }
}