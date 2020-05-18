using Consulting.Domains.Core.Customer.Repositories;
using Consulting.Domains.Core.Entities;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.Extensions.Configuration;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class SkillRepository : EFCoreRepository<Skill>, ISkillRepository
    {
      //  private AppDBContext Context { set; get; }

        private IConfiguration _configuration;
        private int _take;

        public SkillRepository(IContextProviderFactory contextProvider , IConfiguration configuration) : base(contextProvider)
        {
          //  Context = context;
            _configuration = configuration;
            _take = int.Parse(_configuration.GetSection("paging").GetSection("Take").Value);
        }                     
    }

 }


