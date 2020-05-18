using AutoMapper;
using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Consulting.Domains.Core.Core.Entities;
using Microsoft.AspNetCore.Http;
using Consulting.Applications.AppService.ServiceDto.FileUploadDto;
using Consulting.Applications.AppService.ServiceDto.BasicDto;

namespace Consulting.Applications.AppService.FileManagement
{
    public class UploadAppService
    {
        
        private UploadService _uploadService;

        private IMapper _mapper;

        private ITransactionManager _transactionManager;

        public UploadAppService( ITransactionManager transactionManager, IMapper mapper,
            UploadService uploadService )
        {
            _uploadService = uploadService;

            _mapper = mapper;

            _transactionManager = transactionManager; 
                      
        }

        public async Task CreateAttachmentAsync(AttachmentDto attachmentDto)
        {
            var attachment = _mapper.Map<Attachment>(attachmentDto);
            await _uploadService.CreateAttachment(attachment);
            await _transactionManager.SaveAllAsync();
        }


        public async Task<string> CreateDirectoryAndFile(int? entityID, string dtoName, IFormFile file)
        {
            var folderName = Path.Combine("Resources", "Images", dtoName, entityID.ToString());
            if(Directory.Exists(folderName))           
                    Directory.Delete(folderName, true);
            
            System.IO.Directory.CreateDirectory(folderName);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            FileInfo fileee = new FileInfo(file.FileName);

            var fileName = Guid.NewGuid().ToString() + fileee.Extension;
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
              await  file.CopyToAsync(stream);
            }

            var dbPath = Path.Combine(folderName, fileName);
            dbPath = dbPath.Replace('\\', '/');
            return dbPath;
        }


        public async Task RemoveAttachmentAsync(AttachmentDto attachmentDto)
        {
            var attachment = _mapper.Map<Attachment>(attachmentDto);
            await _uploadService.DeleteAttachment(attachment);
            await _transactionManager.SaveAllAsync();
        }


        public async Task<ResultListDto> GetAllAttachmentsAsync(AttachmentFilterDto attachmentDto)
        {
            var attachmentFilter = _mapper.Map<AttachmentFilter>(attachmentDto);

            var fileList = await _uploadService.GetFilesAsync(attachmentFilter);

            List<Attachment> attachments =(List<Attachment>) fileList.Results; 
            
            List<AttachmentDto> attachmentDtos =new List<AttachmentDto>();

             attachments?.ForEach(x =>
            {
                AttachmentDto dto = new AttachmentDto();
                dto = _mapper.Map<AttachmentDto>(x);
              dto.AttachmentType = _mapper.Map<KeyValueDto>(x.AttachmentType);
                attachmentDtos.Add(dto);
            });
                        
            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = fileList.MaxPageRows,
                TotalRows = fileList.TotalRows,
                Results = attachmentDtos , 
            };

            return finalResult;
        }


        public async Task<ResultListDto> GetAllAttachmentTypesAsync(int categoryID)
        {

            var fileList = await _uploadService.GetAttachmentTypesAsync(categoryID);

            var fileDtoDtoList = _mapper.Map<IEnumerable<KeyValueDto>>(fileList.Results);


            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = fileList.MaxPageRows,
                TotalRows = fileList.TotalRows,
                Results = fileDtoDtoList,
            };
            return finalResult;
        }



        public async Task<List<string>> CheckAllFilesGetFromUserAsync(AttachmentFilterDto attachmentDto)
        {
            List<string> fileNotImport = new List<string>();

            var types = await _uploadService.GetRequierdAttachmentTypesAsync(attachmentDto.CategoryID);

            var typeResults = (IEnumerable<AttachmentType>) types.Results ;
            attachmentDto.WithPaging = false;
            var attachments = await GetAllAttachmentsAsync(attachmentDto);

            var results = (IEnumerable<AttachmentDto>) attachments.Results ;

           //// bool exist = false;
           // int typeCounter = 0;
           // foreach (var item in typeResults)
           // {              

           //     foreach (var att in results)
           //     {
           //         if (att.AttachmentType.ID == item.ID)
           //         {
           //             typeCounter += 1;
           //         }
           //     }

           //     if (typeCounter < item.AttachmentTypeCount )
           //     {
           //       //  fileNotImport.Add($"فایل {item.AttachmentTypeDesc} وارد نشده" );
           //         fileNotImport.Add($"فایل {item.AttachmentTypeDesc} به تعداد کافی وارد نشده است تعداد : {Math.Abs(typeCounter - item.AttachmentTypeCount)}");
           //     }

           //     typeCounter = 0;
           // }

             bool exist = false;
            foreach (var item in typeResults)
            {

                foreach (var att in results)
                {
                    if (att.AttachmentType.ID == item.ID)
                    {
                        exist = true;
                    }
                }

                if (!exist)
                {
                      fileNotImport.Add($"فایل {item.AttachmentTypeDesc} وارد نشده" );
                    exist = false;
                }

                exist = false;
            }


            if (fileNotImport.Count > 0)
            {
                fileNotImport.Add("لطفا تمامی فایلهای مربوطه را وارد کنید");
            }

            return fileNotImport;
        }



        public async Task<ResultObject> GetFileWithAttachmentTypeAsync(AttachmentDto attachmentFilterDto)
        {
            ResultObject resultObject = new ResultObject();

            var att = _mapper.Map<Attachment>(attachmentFilterDto); 


            var file = await _uploadService.CheckIfFileAlreadyExistsAsync(att);
            if (file)
            {
                resultObject.ServerErrors.Add(new ServerErr() { Hint = $"فایل  {attachmentFilterDto.AttachmentType.Desc}  قبلا ثبت شده است" });
            }

            return resultObject;       
        }

        public async Task RemoveAllPersonImages(int userID)
        {
            await _uploadService.RemoveAllPersonImages(userID);
        }
    }
}



