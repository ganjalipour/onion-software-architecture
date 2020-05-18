using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Core.Entities;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Customer.Entities;
using Consulting.Domains.Customer.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Customer.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerHead>
    {
        Task<CustomerHead> GetCustomerByCustomerIdAsync(int customerId);

        Task<CustomerHead> GetCustomerAsync(int customerNumber);

        Task<CustomerHead> GetCustomerByNationalCodeAndBranchIDAsync(string nationalCode);

        Task<ResultList> GetAllCustomersByFilter(CustomerFilter filterDto);

        Task<ResultList> GetAllBranchCustomerHeadsAsync(CustomerFilter customerFilter);

        Task<IEnumerable<Nationality>> GetNantionalities();

        Task<IEnumerable<MilitaryServiceStatus>> GetMilitaryServiceStatuses();

        Task<IEnumerable<EducationLevels>> GetEducationalLevels();

        Task<IEnumerable<Skill>> GetSkills();
        Task AddCustomerSkill(CustomerSkill customerSkill);
        Task UpdateCustomerSkills(IEnumerable<CustomerSkill> skills, int customerID);
    }
}