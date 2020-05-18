using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consulting.Common.Model;
using Microsoft.EntityFrameworkCore.Storage;
using Consulting.Common.Constants;

namespace Consulting.Domains.Core.Service
{
    public class UserService
    {

        private IUserRepository userRepository;
        private IUserRoleRepository userRolesRepository;
        private IUserBranchRepository userBranchRepository;
        private IBranchRepository branchRepository;
        private IZoneRepository zoneRepository;
        public UserService(IUserRepository _userRepository, IUserRoleRepository _userRolesRepository, IUserBranchRepository _userBranchRepository , IBranchRepository _branchRepository , IZoneRepository _zoneRepository)
        {
            userRepository = _userRepository;
            branchRepository = _branchRepository;
            zoneRepository = _zoneRepository;
            userRolesRepository = _userRolesRepository;
            userBranchRepository = _userBranchRepository;
        }

        public async Task CreateUserAsync(User user)
        {          
            await userRepository.AddAsync(user);
        }

        public async Task<List<User>> GetUsersBasedOnRoleAsync(UserBranches userBranches)
        {
            List<User> userList = new List<User>();
            var userRoles = await userRolesRepository.GetUserRolesAsync(userBranches.BranchId, userBranches.UserId);
            foreach (var item in userRoles)
            {
                if (item.RoleId == ConstRoles.Admin)
                {
                    UserFilter userFilter = new UserFilter();
                    var users = await userRepository.GetByPredicateAsync(X=>X.ID != userBranches.UserId);
                    userList = users.ToList();
                    return userList;
                }
                else if (item.RoleId == ConstRoles.SuperViser)
                {
                    var branch = await branchRepository.GetBranchAsync(userBranches.BranchId);

                    var zone = await zoneRepository.GetZoneInfoByZoneIDAsync(branch.ZoneID);

                    var branches = await zoneRepository.GetProvinceBranchesByProvinceCode(zone.OSTANCode);

                    var users = await userRepository.GetUsereOfBranches(branches);

                    users = users.Where(X => X.ID != userBranches.UserId);

                    userList = users.ToList();
                    return userList;
                }
                else 
                {
                   // var users = await userRepository.GetUsereOfBranche(userBranches.BranchId);

                    //users = users.Where(X => X.ID != userBranches.UserId);

                    //userList = users.ToList();
                }
            }
            return null;
        }

        public async Task<IDbContextTransaction> CreateUserByUserBranchAsync(User user)
        {
           return await userRepository.CreateUserByUserBranchAsync(user);           
        }

        public async Task<User> FindUserByUserPass(string userName, string password, int branchID)
        {
            return await userRepository.GetUser(userName, password, branchID);
        }

        public async Task<User> FindUserByNationalCode(string nationalCode)
        {
            return await userRepository.FindByFirstOrDefaultAsync(x => x.NationalCode == nationalCode);
        }

        public async Task<bool> CheckUserNameRepeatAsync(string userName)
        {
            return await userRepository.CheckUserNameRepeatAsync(userName);
        }

        public async Task<User> GetUserAsync(int Id)
        {
            return await userRepository.FindByFirstOrDefaultAsync(item => item.ID == Id);
        }

        public async Task<ResultList> GetUsersAsync(UserFilter userFilter)
        {
            var users = await userRepository.GetAllUsersAsync(userFilter);
            return users;
        }

        public async Task<User> GetUserByNationalCodeAsync(string nationalCode)
        {
            return await userRepository.FindByFirstOrDefaultAsync(x=>x.NationalCode == nationalCode);
        }


        public async Task<User> UpdateUserAsync(User user)
        {
            return await userRepository.UpdateAsync(user, user.ID);
        }

        public async Task RemoveUserAsync(User user)
        {
            await userRepository.RemoveAsync(user.ID);
        }

        public async Task<IEnumerable<UserBranchRole>> GetUserRolesAsync(int userID, int branchID)
        {
            return await userRolesRepository.GetUserRolesAsync(userID, branchID);
        }



        public async Task<UserBranchRole> GetUserRoleAsync(int id)
        {
            return await userRolesRepository.GetUserRoleAsync(id);
        }

        public async Task<ResultObject> CreateUserRoleAsync(UserBranchRole userRole)
        {
          return  await userRolesRepository.AddUserBranchRole(userRole);
        }
        public async Task<ResultObject> UpdateUserRoleAsync(UserBranchRole userRole)
        {
            return await userRolesRepository.UpdateUserBranchRoleAsync(userRole);
        }

        public async Task RemoveUserRoleAsync(UserBranchRole userRole)
        {
            await userRolesRepository.RemoveAsync(userRole.ID);
        }

        public async Task<IEnumerable<UserBranches>> GetUserBranchesAsync(int id)
        {
            return await userBranchRepository.GetUserBranchesAsync(id);
        }

        public async Task<IEnumerable<UserBranches>> GetUserBranchesByBranchIDAsync(int branchID)
        {
            return await userBranchRepository.GetUserBranchesByBranchIDAsync(branchID);
        }

        public async Task<UserBranches> GetUserbranchAsync(int id)
        {
            return await userBranchRepository.GetUserBranchAsync(id);
        }
        public async Task<ResultObject> CreateUserbranchAsync(UserBranches userBranch)
        {
           return await userBranchRepository.AddUserBranchAsync(userBranch);
        }
        public async Task<ResultObject> UpdateUserBranchAsync(UserBranches userBranch)
        {
            return await userBranchRepository.UpdateUserBranchAsync(userBranch, userBranch.ID);
        }

        public async Task RemoveUserBrancheAsync(UserBranches userBranch)
        {
            await userBranchRepository.RemoveAsync(userBranch.ID);

        }

        public async Task<ResultObject> ChangePasswordAsync(int userID, string newPassword, string password, bool fromChangePassForm)
        {
           return await userRepository.ChangePasswordAsync(userID, newPassword, password, fromChangePassForm);
        }
        public async Task<IEnumerable<UserBranchRole>> GetUserRolesAsync(UserBranchRole userBranchRole) {
            return await userRepository.GetUserRolesAsync(userBranchRole);
        }

        //public async Task<IEnumerable<User>> GetUsersAsync(UserFilter userFilterDao)
        //{       
        //    return await userRepository.filterQuery(userFilterDao);
        //}

    }
}
