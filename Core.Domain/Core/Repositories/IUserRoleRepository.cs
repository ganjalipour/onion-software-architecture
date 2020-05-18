using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
    public interface IUserRoleRepository : IRepository<UserBranchRole>
    {
        Task<IEnumerable<UserBranchRole>> GetUserRolesAsync(int userID, int branchID);
        Task<UserBranchRole> GetUserRoleAsync(int id);
        Task<ResultObject> AddUserBranchRole(UserBranchRole userRole);
        Task<ResultObject> UpdateUserBranchRoleAsync(UserBranchRole userRole);
    }
}
