using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consulting.Common.Model;
using Consulting.Common.Constants;
using Consulting.Common.Dto;
using Consulting.Domains.Customer.Repositories;

namespace Consulting.Domains.Core.Service
{
    public class BranchService
    {
        private IBranchRepository _branchRepository;
        private IZoneRepository _zoneRepository;
        private IUserRepository _userRepository;
        private IUserRoleRepository _userRoleRepository;
        private ICustomerRepository _customerRepository;


        public BranchService(IBranchRepository branchRepository, IZoneRepository zoneRepository,
            IUserRepository userRepository, IUserRoleRepository userRoleRepository, ICustomerRepository customerRepository)
        {
            _branchRepository = branchRepository;
            _customerRepository = customerRepository;
            _userRoleRepository = userRoleRepository;
            _zoneRepository = zoneRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Branch>> GetUserBranches(int userID)
        {
            return await _branchRepository.GetUserBranches(userID);
        }

        public async Task<Branch> GetBranchAsync(int id)
        {
            return await _branchRepository.GetBranchAsync(id);
        }

        public async Task<Branch> GetBranchByBranchCodeAsync(string branchCode)
        {
            return await _branchRepository.GetBranchByCodeAsync(branchCode);
        }

        public async Task<List<int>> GetBranchesForFiltersAsync(UserBranches userBranches, BaseFilter filter = null)
        {
            List<int> branchList = new List<int>();
            if(userBranches == null) return branchList;
            var userRoles = await _userRoleRepository.GetUserRolesAsync(userBranches.UserId, userBranches.BranchId);
            var top_priority = userRoles.Min(p => p.Role.Order);

            switch (top_priority)
            {
                case ConstRolesOrder.Admin: return branchList;

                case ConstRolesOrder.User:
                    return branchList;
                case ConstRolesOrder.Customer:
                    return branchList;
                 default:
                    branchList.Add(userBranches.BranchId);
                    break;
            };    
            branchList.Add(userBranches.BranchId);
            return branchList;
        }


        public async Task CreateBranchAsync(Branch branch)
        {
            await _branchRepository.AddAsync(branch);
        }

        public async Task<Branch> UpdateBranchAsync(Branch branch)
        {
            return await _branchRepository.UpdateAsync(branch, branch.ID);
        }



        public async Task<ResultList> GetBranchesAsync(BranchFilter branchFilterDto)
        {
            var branches = await _branchRepository.GetAllBranchAsync(branchFilterDto);
            return branches;
        }

        public async Task<ResultList> GetBranchListAsync(BranchFilter branchFilterDto)
        {
            var branches = await _branchRepository.GetBranchListAsync(branchFilterDto);
            return branches;
        }



        public async Task DeleteBranchAsync(int Id)
        {
            await _branchRepository.RemoveAsync(Id);
        }



    }
}
