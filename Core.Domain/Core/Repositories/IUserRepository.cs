using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<ResultList> GetAllUsersAsync(UserFilter userFilter);
        Task<IEnumerable<User>> GetUsereOfBranches(List<Branch> branchse);

        Task<User> GetUser(string userName, string password, int branchID);
        Task<ResultObject> ChangePasswordAsync(int userID, string newPassword, string password, bool fromChangePassForm);
        Task<IDbContextTransaction> CreateUserByUserBranchAsync(User user);
        Task<bool> CheckUserNameRepeatAsync(string userName);
        Task<IEnumerable<UserBranchRole>> GetUserRolesAsync(UserBranchRole userBranch);
    } 
}
