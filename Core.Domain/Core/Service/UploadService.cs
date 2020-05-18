using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Service

{
    public class UploadService
    {
        private IAttachmentRepository _attachmentReopository; 
        public UploadService(IAttachmentRepository attachmentRepository)
        {
            _attachmentReopository = attachmentRepository;
        }

        public async Task  CreateAttachment(Attachment attachment)
        {
          await  _attachmentReopository.AddAsync(attachment);
        }

        public async Task DeleteAttachment(Attachment attachment)
        {
           await _attachmentReopository.RemoveAsync(attachment.ID);
        }


        public async Task<ResultList> GetFilesAsync(AttachmentFilter attachmentFilter)
        {
           var result = await _attachmentReopository.GetAllFilesAsync(attachmentFilter);
            return result;
        }


        public async Task<ResultList> GetAttachmentTypesAsync(int categoryID)
        {
            var result = await _attachmentReopository.GetAttachmentTypesAsync(categoryID);
            return result;
        }

        public async Task<ResultList> GetRequierdAttachmentTypesAsync(int categoryID)
        {
            var result = await _attachmentReopository.GetRequierdAttachmentTypesAsync(categoryID);
            return result;
        }

        public async Task<bool> CheckIfFileAlreadyExistsAsync(Attachment attachmentFilter)
        {
            var result = await _attachmentReopository.CheckIfFileAlreadyExistsAsync(attachmentFilter);
            return result; 
        }

        public async Task RemoveAllPersonImages(int userID)
        {
            await _attachmentReopository.RemoveAllPersonImages(userID);
        }
    }
}