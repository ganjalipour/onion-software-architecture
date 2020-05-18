using Consulting.Common.Constants;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Data.Repositories.EFCore
{
    public class UserBranchRepository : EFCoreRepository<UserBranches>, IUserBranchRepository
    {
     //   private AppDBContext Context { set; get; }

        public UserBranchRepository(IContextProviderFactory contextProvider) : base(contextProvider)
        {
           // Context = context;
        }

        public async Task<IEnumerable<UserBranches>> GetUserBranchesAsync(int id)
        {
            var UserBranches = Context.UserBranches.Where(u => u.UserId == id).Include(userBranch => userBranch.Branch).ToListAsync();
            return await UserBranches;
        }

        public async Task<UserBranches> GetUserBranchAsync(int id)
        {
            return await Context.UserBranches.Where(p=>p.UserId == id ).Include(p=>p.Branch).FirstOrDefaultAsync();

        }

        public async Task<ResultObject> AddUserBranchAsync(UserBranches userBranch)
        {
            ResultObject resultObject = new ResultObject() { Result = null };
            var ub = Context.UserBranches.Where(p => p.UserId == userBranch.UserId && p.BranchId == userBranch.BranchId).Any();
            if (ub)
            {
                resultObject.ServerErrors.Add(new ServerErr()
                {
                    Hint = "کاربر انتخاب شده دسترسی به شعبه انتخاب شده را دارد",
                    Type = ConstErrorTypes.BussinessError
                });
                return resultObject;
            }
            else
                await Context.UserBranches.AddAsync(userBranch);
            return resultObject;

        }

        public async Task<ResultObject> UpdateUserBranchAsync(UserBranches userBranch, int iD)
        {
            ResultObject resultObject = new ResultObject() { Result = null };
            var ub = Context.UserBranches.Where(p => p.UserId == userBranch.UserId && p.BranchId == userBranch.BranchId).Any();
            if (ub)
            {
                resultObject.ServerErrors.Add(new ServerErr()
                {
                    Hint = "کاربر انتخاب شده دسترسی به شعبه انتخاب شده را دارد",
                    Type = ConstErrorTypes.BussinessError
                });
                return resultObject;
            }
            else
            {
                await this.UpdateAsync(userBranch, userBranch.ID);
                resultObject.Result = userBranch;
            }

            return resultObject;
        }

        public async Task<IEnumerable<UserBranches>> GetUserBranchesByBranchIDAsync(int branchID)
        {
            var UserBranches = await Context.UserBranches.Where(u => u.BranchId == branchID).ToListAsync();
            return  UserBranches;
        }


    }
}
