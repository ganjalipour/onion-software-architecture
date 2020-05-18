using Consulting.Common.Constants;
using Consulting.Common.Model;

using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Domains.Core.Service;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class UserRepository : EFCoreRepository<User>, IUserRepository
    {
        private int _take;
      //  private AppDBContext Context { set; get; }
        public UserRepository(IContextProviderFactory contextProvider , IConfiguration configuration) : base(contextProvider)
        {
           // Context = context;
            _take = int.Parse(configuration.GetSection("paging").GetSection("Take").Value);
        }

        public async Task<ResultList> GetAllUsersAsync(UserFilter userFilter)
        {
            ResultList result = new ResultList();

            var users = (from user in Context.Users
                         //join userBranch in Context.UserBranches
                         //on user.ID equals userBranch.UserId into gub
                         //from ub in gub.DefaultIfEmpty()
                         //where user.IsActive
                         where string.IsNullOrEmpty(userFilter.UserName) || (user.UserName == userFilter.UserName.Trim())
                         where string.IsNullOrEmpty(userFilter.NationalCode) || (user.NationalCode == userFilter.NationalCode.Trim())
                         where string.IsNullOrEmpty(userFilter.FullName) || (user.FirstName + " " + user.LastName).Contains(userFilter.FullName.Trim())
                         //where (userFilter.Branches.Length == 0 || userFilter.Branches.Contains(ub.BranchId))
                         select user);

        

            if (userFilter.SortDto != null && userFilter.SortDto.Count > 0)
                users = ApplySorting(userFilter, users );
            result.TotalRows = users.Count();

            users = users.Skip((userFilter.PageNumber - 1) * _take).Take(_take);
            result.MaxPageRows = _take;
            var userList = await users.ToListAsync();
            result.Results = userList;
            return result;
        }

    
        public async Task<User> GetUser(string userName, string password, int branchID)
        {
            var userInfo = await (from user in Context.Users
                                  where user.UserName == userName && user.Password == password
                                  select new User()
                                  {
                                      ID = user.ID,
                                      IsActive = user.IsActive,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      NationalCode = user.NationalCode,
                                      IsRequireChangePass = user.IsRequireChangePass,
                                      UserName = user.UserName,
                                      Password = user.Password,
                                      PhoneNumber = user.PhoneNumber,
                                      UserBranchRoles = user.UserBranchRoles.Where(p => p.BranchId == branchID).ToList()
                                  }).FirstOrDefaultAsync();
            if (userInfo == null)
                return userInfo;
            userInfo.UserBranches = new List<UserBranches>();
            var UserBranches = await Context.UserBranches.Include(m => m.Branch).
               Where(p => p.UserId == userInfo.ID).ToListAsync();
            userInfo.UserBranches = UserBranches;
            return userInfo;
        }

        public async Task<ResultObject> ChangePasswordAsync(int userID, string newPassword, string password, bool fromChangePassForm)
        {
            ResultObject resultObject = new ResultObject();
            var user = await Context.Users.FindAsync(userID);
            if (user.Password != password && fromChangePassForm)
            {
                resultObject.ServerErrors.Add(new ServerErr() { Hint = "رمز عبور فعلی اشتباه می باشد.", Type = ConstErrorTypes.BussinessError });
                return resultObject;
            }
            user.Password = newPassword;
            user.IsRequireChangePass = false;
            Context.Users.Update(user);
            return resultObject;
        }

        public async Task<bool> CheckUserNameRepeatAsync(string userName)
        {
            var user = await Context.Users.FirstOrDefaultAsync(p => p.UserName == userName);
            if (user != null) return true;
            return false;
        }

        public async Task<IDbContextTransaction> CreateUserByUserBranchAsync(User user)
        {
           var tr =  Context.Database.BeginTransaction();
             await  Context.AddAsync(user);
            return tr;
        }

        public async Task<IEnumerable<UserBranchRole>> GetUserRolesAsync(UserBranchRole userBranchRole)
        {
            var UserBranchRoles = await Context.UserBranchRoles.Where(a => a.UserId == userBranchRole.UserId
            && a.BranchId == userBranchRole.BranchId).Include(p => p.Role)
            .Include(p=>p.Branch).ToListAsync();
            return UserBranchRoles;
        }

        public async Task<IEnumerable<User>> GetUsereOfBranches(List<Branch> branches)
        {
            var branchIDS = from branch in branches
                            select branch.ID;
            var useres = await ( from user in Context.Users
                         join userBranches in Context.UserBranches
                         on user.ID equals userBranches.UserId
                         where branchIDS.Contains(userBranches.BranchId)
                         select user).ToListAsync();

            return useres;

        }


    }
}
