using Consulting.Domains.Customer.Entities;
using Consulting.Domains.Customer.Repositories;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.Extensions.Configuration;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class CustomerDetailsRepository : EFCoreRepository<CustomerDetail>, ICustomerDetailsRepository
    {

        private IConfiguration _configuration;
        private int _take;

        public CustomerDetailsRepository(IContextProviderFactory contextProvider, IConfiguration configuration) : base(contextProvider)
        {
            _configuration = configuration;
            _take = int.Parse(_configuration.GetSection("paging").GetSection("Take").Value);
        }
                 
    }



 }


