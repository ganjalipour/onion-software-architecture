using AutoMapper;
using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Consulting.Common.Constants;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Common.Collections;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using Consulting.Applications.Notification;

namespace Consulting.Applications.AppService.RoleManagement
{
    public class UserAppService
    {
        private UserService _userService;
        private BranchService _branchService;
        private NotificationAppService _notificationAppService;
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        private ITransactionManager _transactionManager;

        public UserAppService(UserService userService, ITransactionManager transactionManager, IMapper mapper, NotificationAppService notificationAppService,
            BranchService branchService, RoleService roleService)
        {
            _userService = userService;
            _notificationAppService = notificationAppService;
            _branchService = branchService;
            _roleService = roleService;
            _mapper = mapper;
            _transactionManager = transactionManager;
        }

        public async Task<ResultObject> CreateUserAsync(UserDto userDto)
        {
            ResultObject resultobject = new ResultObject();
            var us = await _userService.FindUserByNationalCode(userDto.NationalCode);
            if (us != null)
            {
                resultobject.ServerErrors.Add(new ServerErr() { Hint = "کد ملی کاربر نمیتواند تکراری باشد" });
                return resultobject;
            }
            var user = _mapper.Map<User>(userDto);
            if (userDto.IssuerUserID != 0 && userDto.IssuerBranchID != 0)
            {
                //var userRoles = await _userService.GetUserRolesAsync(userDto.IssuerUserID, userDto.IssuerBranchID);
                //if (userRoles.Any(p => p.RoleId == ConstRoles.CEO))
                //user.UserBranches.Add(new UserBranches() { UserId = userDto.ID, BranchId = userDto.IssuerBranchID });
                user.UserBranchRoles.Add(new UserBranchRole()
                {
                    BranchId = 1,
                    RoleId = userDto.IsConsultant ? ConstRoles.Consultant : ConstRoles.Customer
                });
            }

            var hasRepeatUserName = await _userService.CheckUserNameRepeatAsync(user.UserName);
            if (hasRepeatUserName)
            {
                resultobject.Result = null;
                resultobject.ServerErrors.Add(new ServerErr() { Hint = "نام کاربری تکراری است.", Type = ConstErrorTypes.BussinessError });
                return resultobject;
            }

           user.Password = GetHassPassCode(user.Password);

            await _userService.CreateUserAsync(user);
            var result = await _transactionManager.SaveAllAsync();
            if (result > 0)
                resultobject.Result = user.ID;
            return resultobject;
        }


        public async Task<ResultObject> ReCoverPassAsync(RecoverPassDto recoverPassDto)
        {
            ResultObject result = new ResultObject();
            var user = await _userService.FindUserByNationalCode(recoverPassDto.NationalCode);
            if (user == null)
            {
                result.ServerErrors.Add(new ServerErr() { Hint = "کد ملی وارد شده در سامانه موجود نمی باشد.", Type = ConstErrorTypes.BussinessError });
                return result;
            }

            var code = GenerateRandomConfirmCode();
            user.ConfirmCode = code;
            await _userService.UpdateUserAsync(user);
            result.Result = _transactionManager.SaveAllAsync();
            return result;
        }

        private int GenerateRandomConfirmCode()
        {
            var code = new Random().Next(100000, 999999);
            return code;
        }


        public async Task<ResultObject> ConfirmRecoverPass(RecoverPassDto recoverPassDto)
        {
            ResultObject result = new ResultObject();
            var user = await _userService.FindUserByNationalCode(recoverPassDto.NationalCode);
            if (user == null)
            {
                result.ServerErrors.Add(new ServerErr() { Hint = "کد ملی وارد شده در سامانه موجود نمی باشد.", Type = ConstErrorTypes.BussinessError });
                return result;
            }

            if(user.ConfirmCode != recoverPassDto.ConfirmCode)
            {
                result.ServerErrors.Add(new ServerErr() { Hint = "کد فعالسازی معتبر نمی باشد.", Type = ConstErrorTypes.BussinessError });
                return result;
            }
            user.Password = GetHassPassCode(recoverPassDto.Password);
            await _userService.UpdateUserAsync(user);
            result.Result = _transactionManager.SaveAllAsync();
            return result;
        }

        private string GetHassPassCode(string password)
        {
            //generate a 128 - bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
  
           salt = Encoding.UTF8.GetBytes("microfunds");
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            
            return hashed;
        }

        public async Task<bool> CheckUserNameRepeatAsync(string userName)
        {
            return await _userService.CheckUserNameRepeatAsync(userName);
        }

        public async Task<ResultObject> CreateUserByUserBranchAcync(UserDto userDto, UserBranchesDto userBranchesDto)
        {
            ResultObject resultobject = new ResultObject();

            var user = _mapper.Map<User>(userDto);
            var userBranch = _mapper.Map<UserBranches>(userBranchesDto);
            user.UserBranches.Add(userBranch);

            await _userService.CreateUserByUserBranchAsync(user);
            await _transactionManager.SaveAllAsync();
            resultobject.Result = user;
            return resultobject;
        }

        public async Task<ResultObject> UpdateUserAsync(UserDto userDto)
        {
            ResultObject resultobject = new ResultObject();

            var user = _mapper.Map<User>(userDto);
            await _userService.UpdateUserAsync(user);
            resultobject.Result = await _transactionManager.SaveAllAsync();
            return resultobject;
        }

        public async Task<ResultListDto> GetUsersAsync(UserFilterDto userFilterDto)
        {
            var userBranch = _mapper.Map<UserBranches>(userFilterDto.UserBranchDto);
            if(userFilterDto.Branches == null || userFilterDto.Branches.Count == 0)
            userFilterDto.Branches = await _branchService.GetBranchesForFiltersAsync(userBranch);

            var userFilter = _mapper.Map<UserFilter>(userFilterDto);
            var userList = await _userService.GetUsersAsync(userFilter);
            var userDtoList = _mapper.Map<IEnumerable<UserDto>>(userList.Results);
            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = userList.MaxPageRows,
                TotalRows = userList.TotalRows,
                Results = userDtoList
            };
            return finalResult;
        }

        public async Task<ResultListDto> GetUserRolesAsync(int userID, int branchID)
        {
            var userRolesList = await _userService.GetUserRolesAsync(userID, branchID);
            var userRolesDtoList = _mapper.Map<IEnumerable<UserBranchRoleDto>>(userRolesList);
            var resultListdto = new ResultListDto { Results = userRolesDtoList, TotalRows = userRolesDtoList.Count() };
            return resultListdto;
        }

        public async Task<UserBranchRoleDto> GetUserRoleAsync(int id)
        {
            var userRole = await _userService.GetUserRoleAsync(id);
            var userRoleDto = _mapper.Map<UserBranchRoleDto>(userRole);
            return userRoleDto;
        }

        public async Task<UserDto> FindUser(string userName, string password, int branchID)
        {
            password = GetHassPassCode(password);
            var user = await _userService.FindUserByUserPass(userName, password, branchID);
            var userDto = _mapper.Map<UserDto>(user);
            if (userDto == null) return userDto;
            userDto.UserBranch = userDto.UserBranches.Where(p => p.BranchId == branchID).FirstOrDefault();
            return userDto;
        }

        public async Task<UserDto> GetUserByID(int ID)
        {
            var user = await _userService.GetUserAsync(ID);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<User> GetUserByNationalCodeAsync(string nationalCode)
        {
            return await _userService.GetUserByNationalCodeAsync(nationalCode);
        }

        public async Task DeleteUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.RemoveUserAsync(user);
            await _transactionManager.SaveAllAsync();
        }

        public async Task<ResultObject> CreateUserRoleAsync(UserBranchRoleDto userRolesDto)
        {
            var userRole = new UserBranchRole() { UserId = userRolesDto.UserId, RoleId = userRolesDto.RoleId, BranchId = userRolesDto.BranchId };
            var resultObj = await _userService.CreateUserRoleAsync(userRole);
            var user = await _userService.GetUserAsync(userRole.UserId);
           
            resultObj.Result = await _transactionManager.SaveAllAsync();
            return resultObj;
        }

        public async Task<ResultObject> UpdateUserRoleAsync(UserBranchRoleDto userRoleDto)
        {
            var userRole = _mapper.Map<UserBranchRole>(userRoleDto);
            var resultObj = await _userService.UpdateUserRoleAsync(userRole);
            await _transactionManager.SaveAllAsync();
            return resultObj;
        }

        public async Task<int> DeleteUserRoleAsync(UserBranchRoleDto userRolesDto)
        {
            var UserRole = _mapper.Map<UserBranchRole>(userRolesDto);
            await _userService.RemoveUserRoleAsync(UserRole);
            return await _transactionManager.SaveAllAsync();
        }

        public async Task<ResultListDto> GetUserBranchesAsync(int id)
        {
            var userRolesList = await _userService.GetUserBranchesAsync(id);
            var userRolesDtoList = _mapper.Map<IEnumerable<UserBranchesDto>>(userRolesList);

            var resultlistdto = new ResultListDto { Results = userRolesDtoList, TotalRows = userRolesDtoList.Count() };
            return resultlistdto;
        }

        public async Task<UserBranchesDto> GetUserBrancheAsync(int id)
        {
            var userBranch = await _userService.GetUserbranchAsync(id);
            var userBranchDto = _mapper.Map<UserBranchesDto>(userBranch);
            return userBranchDto;
        }

        public async Task<ResultObject> CreateUserBranchesAsync(UserBranchesDto userBranchesDto)
        {
            var userBranch = new UserBranches() { UserId = userBranchesDto.UserId, BranchId = userBranchesDto.BranchId };
            var resultObject = await _userService.CreateUserbranchAsync(userBranch);
            await _transactionManager.SaveAllAsync();
            return resultObject;
        }

        public async Task<ResultObject> UpdateUserBranchesAsync(UserBranchesDto userBranchesDto)
        {
            var userBranche = _mapper.Map<UserBranches>(userBranchesDto);
            var resultObject = await _userService.UpdateUserBranchAsync(userBranche);
            await _transactionManager.SaveAllAsync();
            var userBranchDto = _mapper.Map<UserBranchesDto>(resultObject.Result);
            resultObject.Result = userBranchDto;
            return resultObject;
        }

        public async Task<ResultObject> ChangePasswordAsync(PasswordDto passwordDto)
        {
            passwordDto.Password = GetHassPassCode(passwordDto.Password);
            passwordDto.NewPassword = GetHassPassCode(passwordDto.NewPassword);
            ResultObject resultobject = await _userService.ChangePasswordAsync(passwordDto.UserID, passwordDto.NewPassword, passwordDto.Password, passwordDto.FromChangePassForm);
            await _transactionManager.SaveAllAsync();
            if (resultobject.ServerErrors.Count == 0)
                resultobject.Result = true;
            return resultobject;
        }

        public async Task<int> DeleteUserBrancheAsync(UserBranchesDto userBranchesDto)
        {
            var userBranch = _mapper.Map<UserBranches>(userBranchesDto);
            await _userService.RemoveUserBrancheAsync(userBranch);
            return await _transactionManager.SaveAllAsync();
        }


        public async Task<ResultList> GetUserRoleInfoAsync(UserBranchRoleDto userBranchRoleDto)
        {
            var userBranchRole = _mapper.Map<UserBranchRole>(userBranchRoleDto);
            var userBranchRoleList = await _userService.GetUserRolesAsync(userBranchRole);
            var userBranchRoleListDto = _mapper.Map<IEnumerable<UserBranchRoleDto>>(userBranchRoleList);
            ResultList resultList = new ResultList();
            resultList.Results = userBranchRoleListDto;
            return resultList;
        }

        public async Task<ResultList> GetUserRolesAsync(UserBranchRoleDto userBranchRoleDto)
        {
            var userBranchRole = _mapper.Map<UserBranchRole>(userBranchRoleDto);
            var userBranchRoleList = await _userService.GetUserRolesAsync(userBranchRole);
            var roles = await _roleService.GetRolesAsync();
            var top_Priority = userBranchRoleList.Min(p => p.Role.Order);
            roles.ForEach(p => p.UserBranchRoles = null);
            if (userBranchRoleDto.UserId != ConstUserIDs.Administrator)
                roles = roles.Where(p => p.Order > top_Priority);
            //userBranchRoleListDto = userBranchRoleListDto.OrderBy(p => p.RoleOrder).Where((p,index)
            //    => index > 0);
            ResultList resultList = new ResultList();
            resultList.Results = roles;
            return resultList;
        }


        //public async Task<IEnumerable<UserDto>> GetUsersAsync(UserFilterDto userFilterDao)
        //{       
        //        var uFilterDao = _mapper.Map<UserFilter>(userFilterDao);

        //        var userList = await _userService.GetUsersAsync(uFilterDao);
        //        var userDtoList = _mapper.Map<IEnumerable<UserDto>>(userList);
        //        return userDtoList;           
        //}
    }
}
