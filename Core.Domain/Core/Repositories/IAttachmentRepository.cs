using Consulting.Common.Constants;
using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
    public interface IAttachmentRepository: IRepository<Attachment>
    {
        Task<ResultList> GetAllFilesAsync(AttachmentFilter filterDto);

        Task<ResultList> GetAttachmentTypesAsync(int categoryID);

        Task<ResultList> GetRequierdAttachmentTypesAsync(int categoryID);

        Task<bool> CheckIfFileAlreadyExistsAsync(Attachment filter);
        Task RemoveAllPersonImages(int userID);
    }
}