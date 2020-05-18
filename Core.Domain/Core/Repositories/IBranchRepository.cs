using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
   public interface IBranchRepository: IRepository<Branch>
    {       
        Task<Branch> GetBranchAsync(int id);
        Task<ResultList> GetAllBranchAsync(BranchFilter filterDto);

        Task<Branch> GetBranchByCodeAsync(string branchCode);
        Task<ResultList> GetBranchListAsync(BranchFilter branchFilterDto);

        Task<List<Branch>> GetUserBranches(int userID); 

    }
}
