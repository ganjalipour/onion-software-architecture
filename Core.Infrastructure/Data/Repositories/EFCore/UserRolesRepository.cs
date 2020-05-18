using Consulting.Common.Constants;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class UserRoleRepository : EFCoreRepository<UserBranchRole>, IUserRoleRepository
    {
      //  private AppDBContext Context { set; get; }
        public UserRoleRepository(IContextProviderFactory contextProvider) : base(contextProvider)
        {
           // Context = context;
        }

        public async Task<IEnumerable<UserBranchRole>> GetUserRolesAsync(int userID, int branchID)
        {
            var userRoles = Context.UserBranchRoles.Where(u=>u.UserId == userID && u.BranchId == branchID).Include(userRole => userRole.Role).ToListAsync();
            return await userRoles;
        }
  
        public async Task<UserBranchRole> GetUserRoleAsync(int id)
        {
            var userRole = Context.UserBranchRoles.FindAsync(id);

            return await userRole;
        }

        public async Task<ResultObject> AddUserBranchRole(UserBranchRole userRole)
        {
            ResultObject resultObject = new ResultObject() { Result = null };
            var ubr = Context.UserBranchRoles.Where(p => p.UserId == userRole.UserId && p.BranchId == userRole.BranchId
            && p.RoleId == userRole.RoleId).Any();
            if (ubr)
            {
                resultObject.ServerErrors.Add(new ServerErr()
                {
                    Hint = "کاربر انتخاب شده در این شعبه، نقش انتخاب شده را دارد",
                    Type = ConstErrorTypes.BussinessError
                });
                return resultObject;
            }
            else
                resultObject.Result = await Context.UserBranchRoles.AddAsync(userRole);
            return resultObject;
        }

        public async Task<ResultObject> UpdateUserBranchRoleAsync(UserBranchRole userRole)
        {
            ResultObject resultObject = new ResultObject() { Result = null };
            var ubr = Context.UserBranchRoles.Where(p => p.UserId == userRole.UserId && p.BranchId == userRole.BranchId && p.RoleId == userRole.RoleId).Any();
            if (ubr)
            {
                resultObject.ServerErrors.Add(new ServerErr()
                {
                    Hint = "کاربر انتخاب شده در این شعبه، نقش انتخاب شده را دارد",
                    Type = ConstErrorTypes.BussinessError
                });
                return resultObject;
            }
            else
                resultObject.Result = await UpdateAsync(userRole, userRole.ID);

            return resultObject;
        }
    }
}
