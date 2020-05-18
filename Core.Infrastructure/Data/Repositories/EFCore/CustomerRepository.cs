using Consulting.Common.Model;
using Consulting.Domains.Core.Core.Entities;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Customer.Entities;
using Consulting.Domains.Customer.Repositories;
using Consulting.Domains.Customer.Service;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class CustomerRepository : EFCoreRepository<CustomerHead>, ICustomerRepository
    {
        private IConfiguration _configuration;
        private int _take;

        public CustomerRepository(IContextProviderFactory contextProvider , IConfiguration configuration) : base(contextProvider)
        {
            _configuration = configuration;
            _take = int.Parse(_configuration.GetSection("paging").GetSection("Take").Value);
        }

        public async Task<CustomerHead> GetCustomerByCustomerIdAsync(int customerId)
        {
            var customer = await Context.CustomerHeads.Include(x => x.CustomerDetails)
                .ThenInclude(g => g.CustomerDetailType).Where(x => x.ID == customerId)
                .Include(a=>a.CustomerSkills)
                .Include(a=>a.EducationLevel)
                .Include(a=>a.CustomerDetails)
                .Include(a=>a.Attachments).ThenInclude(b=>b.AttachmentType)
                .SingleOrDefaultAsync();

            var branch = await Context.Branches.FirstOrDefaultAsync(p=>p.ID == customer.BranchID);
            return customer;
        }

        public async Task<CustomerHead> GetCustomerAsync(int customerNumber)
        {

            var customer = await Context.CustomerHeads.
                Include(x => x.CustomerDetails)
                .ThenInclude(g => g.CustomerDetailType).Where(x => x.Serial == customerNumber).FirstOrDefaultAsync();

            return customer;
        }


        public async Task<ResultList> GetAllCustomersByFilter(CustomerFilter filterDto)
        {
            var customers =  Context.CustomerHeads
                .Include(x => x.CustomerSkills)
                .Include(x => x.CustomerDetails)
                .ThenInclude(g => g.CustomerDetailType)
                as IQueryable<CustomerHead>;

            customers =  customers
           .Where(x => string.IsNullOrEmpty(filterDto.FirstName) || x.FirstName.Contains(filterDto.FirstName))
                                        .Where(x => string.IsNullOrEmpty(filterDto.LastName) || x.LastName.Contains(filterDto.LastName))
                                        .Where(x => string.IsNullOrEmpty(filterDto.FatherName) || x.FatherName.Contains(filterDto.FatherName))
                                        .Where(x => string.IsNullOrEmpty(filterDto.CompanyName) || x.FatherName.Contains(filterDto.CompanyName))
                                        .Where(x => filterDto.NationalCode == null || x.NationalCode == filterDto.NationalCode)
                                        .Where(x => filterDto.MilitaryServiceStatusID == 0 || x.MilitaryServiceStatusID == filterDto.MilitaryServiceStatusID)
                                        .Where(x => filterDto.NationalityID == 0 || x.NationalityID == filterDto.NationalityID)
                                        .Where(x => filterDto.Serial == 0 || x.Serial == filterDto.Serial)
                                        .Where(x => filterDto.LastEducationLevelID == 0 || x.LastEducationLevelID == filterDto.LastEducationLevelID)
                                        .Where(x => filterDto.Dependants == 0 || x.Dependants == filterDto.Dependants)
                                        .Where(x => x.IsCompany == filterDto.IsCompany)
                                        .Where(x => filterDto.EconomicCode == 0 || x.EconomicCode == filterDto.EconomicCode)
                                        .Where(x => filterDto.RegisterationCode == 0 || x.RegisterationCode == filterDto.RegisterationCode)
                                        .Where(x => string.IsNullOrEmpty(filterDto.BranchCode) || x.BranchCode.Contains(filterDto.BranchCode))
                .Where(x => filterDto.IsMale == null || x.IsMale == filterDto.IsMale)
                .Where(x => filterDto.IsMaried == null || x.IsMaried == filterDto.IsMaried)
                 .Where(p => filterDto.Branches.Length == 0 || filterDto.Branches.Contains(p.BranchID));

            var result = new ResultList();

            result.TotalRows = customers.Count();
            var take = filterDto.IsLookUp ? int.Parse(_configuration.GetSection("paging").GetSection("LookUpTake").Value) : _take;
            customers = customers.Skip((filterDto.PageNumber - 1) * take).Take(take);
            result.MaxPageRows = take;
            result.Results = await customers.ToListAsync();
            return result;
        }


        public async Task<IEnumerable<Nationality>> GetNantionalities()
        {
            return await Context.Nationalities.ToListAsync();
        }

        public async Task<IEnumerable<MilitaryServiceStatus>> GetMilitaryServiceStatuses()
        {
            return await Context.MilitaryServiceStatuses.ToListAsync();
        }

        public async Task<IEnumerable<EducationLevels>> GetEducationalLevels()
        {
            return await Context.EducationLevels.ToListAsync();
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            return await Context.Skills.ToListAsync();
        }

        public async Task AddCustomerSkill(CustomerSkill customerSkill)
        {
            await Context.CustomerSkills.AddAsync(customerSkill);
        }

        public async Task<CustomerHead> GetCustomerByNationalCodeAndBranchIDAsync(string nationalCode)
        {
           return await Context.CustomerHeads.FirstOrDefaultAsync(x => x.NationalCode == nationalCode);
        }

        public async Task<ResultList> GetAllBranchCustomerHeadsAsync(CustomerFilter customerFilter)
        {
            var result = new ResultList();

            var customers = Context.CustomerHeads as IQueryable<CustomerHead>;

            customers = customers                    
                 .Where(p => customerFilter.BranchID == 0 || customerFilter.BranchID == p.BranchID) ;


            result.TotalRows = customers.Count();

            if (customerFilter.PageNumber != 0)
            {
                customers = customers.Skip((customerFilter.PageNumber - 1) * _take).Take(_take);
            }
            result.MaxPageRows = _take;


            result.Results = await customers.ToListAsync();
            return result;
        }

        public async Task UpdateCustomerSkills(IEnumerable<CustomerSkill> skills, int customerID)
        {
            var prevSkills = await Context.CustomerSkills.Where(p => p.CustomerID == customerID).ToListAsync();
            Context.CustomerSkills.RemoveRange(prevSkills);
            foreach(var item in skills)
            {
                if (item.ID == 0)
                    Context.CustomerSkills.Add(item);
            }
        }
    }


    public class JoinModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { set; get; }

        public DateTime BirthDate { get; set; }

        public int SSH { get; set; }

        public int NationalCode { get; set; }

        public int AccountStatusID { get; set; }

        public int SeriChar { get; set; }

        public int SeriNo { get; set; }

        public int Serial { get; set; }

        public bool IsMale { get; set; }

        public bool IsMaried { get; set; }

        public int CityID { get; set; }//table

        public int CustomerGroupID { get; set; }//table

        public int MilitaryServiceStatusID { get; set; }//table

        public int NationalityID { get; set; }//table

        public int LastEducationLevelID { get; set; }//table

        public string Job { get; set; }

        public int Dependants { get; set; }
      
        public bool IsCompany { get; set; }

        public string CompanyName { get; set; }

        public int EconomicCode { get; set; }

        public int RegisterationCode { get; set; }

        public string CustomerDetailValue { get; set; }

        public string CustomerDetailTypeValue { get; set; }

        public int CustomerDetailTypeID { get; set; }

        public int CustomerDetailID { get; set; }
    }
    

 }


