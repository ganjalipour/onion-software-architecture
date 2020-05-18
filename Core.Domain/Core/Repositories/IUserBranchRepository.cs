using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
   public interface IUserBranchRepository : IRepository<UserBranches>
    {
        Task<IEnumerable<UserBranches>> GetUserBranchesAsync(int id);
        Task<IEnumerable<UserBranches>> GetUserBranchesByBranchIDAsync(int branchID);
        Task<UserBranches> GetUserBranchAsync(int id);
        Task<ResultObject> AddUserBranchAsync(UserBranches userBranch);
        Task<ResultObject> UpdateUserBranchAsync(UserBranches userBranch, int iD);
    }
}
