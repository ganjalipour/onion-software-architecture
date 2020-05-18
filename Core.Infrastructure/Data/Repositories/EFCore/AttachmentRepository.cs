using Consulting.Common.Constants;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Domains.Core.Service;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class AttachmentRepository : EFCoreRepository<Attachment>, IAttachmentRepository
    {
     //   private AppDBContext Context { set; get; }

        private IConfiguration _configuration;

        private int _take;

        public AttachmentRepository(IContextProviderFactory contextProvider , IConfiguration configuration) : base(contextProvider)
        {
           // Context = context;
            _configuration = configuration;
            _take = int.Parse(_configuration.GetSection("paging").GetSection("Take").Value);
        }

        public async Task<ResultList> GetAllFilesAsync(AttachmentFilter filterDto)
        {
            IQueryable<Attachment> files = Context.Attachments.Include(x => x.AttachmentType);

            files = files.Where(x => filterDto.CustomerID == 0 || x.CustomerHeadID == filterDto.CustomerID)
            .Where(x => filterDto.UserID == 0 || x.UserID == filterDto.UserID)
            .Where(x => filterDto.SessionID == 0 || x.SessionID == filterDto.SessionID);


            ResultList resultList = new ResultList()
            {

                TotalRows = files.Count(),
                MaxPageRows = _take
            };

            if (filterDto.WithPaging)
            {
                files = files.Skip((filterDto.PageNumber - 1) * _take).Take(_take);
            }

            resultList.Results = await files.ToListAsync();

            return resultList;
        }


        public async Task<ResultList> GetAttachmentTypesAsync(int categoryID)
        {
            var attachmentTypes = await Context.AttachmentTypes.Where(x=>x.AttachmentTypeCategoryID == categoryID).ToListAsync();
            ResultList resultList = new ResultList()
            {
                TotalRows = attachmentTypes.Count(),
                MaxPageRows = _take,
                Results = attachmentTypes
            };
            return resultList;
        }

        public async Task<ResultList> GetRequierdAttachmentTypesAsync(int categoryID)
        {
            var attachmentTypes = await Context.AttachmentTypes.Where(x => x.AttachmentTypeCategoryID == categoryID && x.IsRequierd == true).ToListAsync();
            ResultList resultList = new ResultList()
            {
                TotalRows = attachmentTypes.Count(),
                MaxPageRows = _take,
                Results = attachmentTypes
            };
            return resultList;
        }


        public async Task<bool> CheckIfFileAlreadyExistsAsync(Attachment filter)
        {
            var res = await Context.Attachments.Include(x=>x.AttachmentType)
                  .Where(x => filter.CustomerHeadID == 0 || x.CustomerHeadID == filter.CustomerHeadID)
                  .Where(x => filter.UserID == 0 || x.UserID == filter.UserID)
                  .Where(x => x.AttachmentTypeID == filter.AttachmentTypeID).ToListAsync();

            var types = await Context.AttachmentTypes.Where(x => x.ID == filter.AttachmentTypeID).FirstOrDefaultAsync();

            return false;
        }

        public async Task RemoveAllPersonImages(int userID)
        {
            var attachements = await Context.Attachments.Where(p => p.UserID == userID
           && p.AttachmentTypeID == ConstAttachmentTypes.PersonImage).ToListAsync();

            Context.Attachments.RemoveRange(attachements);
        }
    }
    

}
