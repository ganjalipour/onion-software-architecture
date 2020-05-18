using Consulting.Common.Model;
using Consulting.Domains.Core.Consult.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Domains.Core.Service;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class ConsultRepository : EFCoreRepository<Consultant>, IConsultRepository
    {
        private IConfiguration _configuration;
        private int _take;

        public ConsultRepository(IContextProviderFactory contextProvider , IConfiguration configuration) : base(contextProvider)
        {
           // Context = context;
            _configuration = configuration;
            _take = int.Parse(_configuration.GetSection("paging").GetSection("Take").Value);
        }

        public async Task<ResultObject> GetConsultantByIDAsync(int id)
        {
            var consultant = await Context.Consultants.Where(p => p.ID == id).Include(p => p.User)
                .Include(p => p.ConsultType).Include(p => p.Expertises).FirstOrDefaultAsync();

            ResultObject result = new ResultObject() { Result = consultant };
            return result;
        }

        public async Task<ResultList> GetConsultantsAsync(ConsultantFilter consultantFilter)
        {
            var consultants = await Context.Consultants.Include(p => p.User).Include(p => p.ConsultType)
                .Include(p => p.Expertises).ToListAsync();

            ResultList result = new ResultList() { entities = consultants };
            return result;

        }
    }
    

}
