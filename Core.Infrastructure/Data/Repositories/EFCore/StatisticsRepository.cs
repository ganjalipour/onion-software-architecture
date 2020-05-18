using Consulting.Infrastructure.Data.Repositories.EFCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Domains.Customer.Entities;
using Consulting.Domains.Customer.Repositories;
using Consulting.Domains.Customer.Service;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class StatisticsRepository : EFCoreRepository<GeneralStatisticsDAO>, IStatisticsRepository
    {
      //  private AppDBContext Context { set; get; }
        private int _take;
        private IConfiguration _configuration;
        public StatisticsRepository(IContextProviderFactory contextProvider , IConfiguration configuration) : base(contextProvider)
        {
          //  Context = context;
            _configuration = configuration;
            _take = int.Parse(_configuration.GetSection("paging").GetSection("Take").Value);
        }


        public async Task<GeneralStatisticsDAO> GetGeneralStatisticsAsync(GeneralStatisticsFilter filter)
        {
            var counts = new
            {
                customersCount = await Context.CustomerHeads.CountAsync(a => a.BranchID == filter.BranchId),
            };
            return new GeneralStatisticsDAO()
            {
                TotalCustomersCount = counts.customersCount,
            };
        }
    }
}
