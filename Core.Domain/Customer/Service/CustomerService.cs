using Consulting.Common.Model;
using Consulting.Domains.Core.Core.Entities;
using Consulting.Domains.Core.Customer.Repositories;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Customer.Entities;
using Consulting.Domains.Customer.Repositories;
using Consulting.Domains.Customer.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Customer.Service
{
    public class CustomerService
    {
        private ICustomerRepository customerRepository;
        private ICustomerDetailsRepository customerDetailRepository;
        private ISkillRepository skillRepository;

        public CustomerService(ICustomerRepository _customerRepository, ICustomerDetailsRepository _customerDetailsRepository, ISkillRepository _skillRepository)
        {
            customerRepository = _customerRepository;
            customerDetailRepository = _customerDetailsRepository;
            skillRepository = _skillRepository;
        }

        public async Task<CustomerHead> GetCustomerByCustomerIdAsync(int customerId)
        {
            return await customerRepository.GetCustomerByCustomerIdAsync(customerId);
        }

        public async Task<CustomerHead> GetCustomerAsync(int customerNumber)
        {
            return await customerRepository.GetCustomerAsync(customerNumber);
        }

        public async Task<CustomerHead> GetCustomerByUserIDAsync(int userID)
        {
            return await customerRepository.FindByFirstOrDefaultAsync(x => x.CustomerUserID == userID);
        }


        public async Task<CustomerHead> GetCustomerByNationalCodeAndBranchIDAsync(string nationalCode)
        {
            return await customerRepository.GetCustomerByNationalCodeAndBranchIDAsync(nationalCode);
        }

        public async Task<IEnumerable<CustomerHead>> GetCustomersAsync()
        {
            return await customerRepository.GetByPredicateAsync();
        }

        public async Task CreateCustomerAsync(CustomerHead customer)
        {
            await customerRepository.AddAsync(customer);
        }

        public async Task CreateCustomerSkill(CustomerSkill customerSkill)
        {
            await customerRepository.AddCustomerSkill(customerSkill);
        }


        public async Task<IEnumerable<EducationLevels>> GetEducationLevels()
        {
            return await customerRepository.GetEducationalLevels();
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            return await customerRepository.GetSkills();
        }

        public async Task<IEnumerable<MilitaryServiceStatus>> GetMilitaryServiceStatus()
        {
            return await customerRepository.GetMilitaryServiceStatuses();
        }

        public async Task<IEnumerable<Nationality>> GetNationalities()
        {
            return await customerRepository.GetNantionalities();
        }

        public async Task<ResultList> GetCustomersByFilterAsync(CustomerFilter customerFilterDto)
        {
            var customers = await customerRepository.GetAllCustomersByFilter(customerFilterDto);
            return customers;
        }


        public async Task<ResultList> GetAllBranchCustomerHeadsAsync(CustomerFilter customerFilter)
        {
            var customers = await customerRepository.GetAllBranchCustomerHeadsAsync(customerFilter);
            return customers;
        }

        public async Task<CustomerHead> UpdateCustomerAsync(CustomerHead customer)
        {
            return await customerRepository.UpdateAsync(customer, customer.ID);
        }

        public async Task AddCustomerDetailsAsync(CustomerDetail customerDetail)
        {
            await customerDetailRepository.AddAsync(customerDetail);
        }

        public async Task AddCustomerSkills(CustomerSkill customerSkill)
        {
            await customerRepository.AddCustomerSkill(customerSkill);
        }

        public async Task UpdateCustomerSkills(IEnumerable<CustomerSkill> skills, int customerID)
        {
             await customerRepository.UpdateCustomerSkills(skills, customerID);
        }

        public async Task<CustomerDetail> UpdateCustomerDetailsAsync(CustomerDetail customerdetails)
        {
            return await customerDetailRepository.UpdateAsync(customerdetails, customerdetails.ID);
        }

        public async Task DeleteCustomerAsync(int Id)
        {
            await customerRepository.RemoveAsync(Id);
        }

    }
}