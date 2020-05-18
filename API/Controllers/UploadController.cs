using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Consulting.Common.Model;
using Consulting.Common.Constants;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.FileUploadDto;
using Consulting.Applications.AppService.ServiceDto.CustomerDto;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Applications.AppService.RoleManagement;

using Consulting.Applications.AppService.FileManagement;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
        private UploadAppService _uploadAppService;
      
        public UploadController(UploadAppService uploadAppService  )
        {
            _uploadAppService = uploadAppService;

        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadFiles")]
        public async Task<ResultObject> UploadFiles([FromForm] ICollection<IFormFile> filess)
        {
            var resultobject = new ResultObject();
        
            var files = Request.Form.Files;
            string attachmentDto = Request.Form["attachmentDto"];
            string dtoName = Request.Form["dtoName"];
            AttachmentDto attDto = Newtonsoft.Json.JsonConvert.DeserializeObject<AttachmentDto>(attachmentDto);
            attDto.File = files[0];
           
            if (files.Any(f => f.Length == 0))
            {
                return new ResultObject { Result = attDto, ServerErrors = null /*new List<ServerErr>().Add(new ServerErr() { Hint = "هیچ فایلی فرستاده نشده است" })*/  };
            }

            if (attDto.AttachmentTypeID == 0 )
            {
                resultobject.ServerErrors.Add(new ServerErr() { Hint = "نوع فایل را وارد کنید" }) ;
                return resultobject;
            }

            string entity = attDto.entity.ToString();

            if (dtoName == ConstAttachmentTypeCategory.Customer.ToString())
            {
                CustomerHeadDto customerDto = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerHeadDto>(entity);
                attDto.CustomerHeadID = customerDto.ID;
                attDto.Path = await _uploadAppService.CreateDirectoryAndFile(attDto.CustomerHeadID.Value, "CustomerDto", attDto.File);
            }

           else if (dtoName == ConstAttachmentTypeCategory.User.ToString())
            {
                UserDto userDto = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(entity);
                attDto.UserID = userDto.ID;
                attDto.Path = await _uploadAppService.CreateDirectoryAndFile(attDto.UserID.Value, "UserDto", attDto.File);
            }



            await _uploadAppService.CreateAttachmentAsync(attDto);

            resultobject.Result = attDto;
            resultobject.ServerErrors = null;

            return  resultobject;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("RemoveUploadedFiles")]
        public async Task<ResultObject> RemoveUploadedFiles(ICollection<IFormFile> filess)
        {
            var files = Request.Form.Files;
            string attachmentDto = Request.Form["attachmentDto"];
            string dtoName = Request.Form["dtoName"];
            AttachmentDto attDto = Newtonsoft.Json.JsonConvert.DeserializeObject<AttachmentDto>(attachmentDto);

            await _uploadAppService.RemoveAttachmentAsync(attDto);


            FileInfo fileInfo = new FileInfo(attDto.Path);

            fileInfo.Delete();

             return new ResultObject { Result = true, ServerErrors = null };
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("GetAllFilesAsync")]
        public async Task<ResultListDto> GetAllFilesAsync(ICollection<IFormFile> filess)
        {
            string dtoName = Request.Form["attachmentTypeCategoryID"];
            string attachmentDto = Request.Form["attachmentDto"];
            string filterDto = Request.Form["filterDto"];

            AttachmentFilterDto filter = Newtonsoft.Json.JsonConvert.DeserializeObject<AttachmentFilterDto>(filterDto);
            AttachmentDto attDto = Newtonsoft.Json.JsonConvert.DeserializeObject<AttachmentDto>(attachmentDto);


            if (dtoName == ConstAttachmentTypeCategory.Customer.ToString())
            {
                var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerHeadDto>(attDto.entity.ToString());
                filter.CustomerID = entity.ID;
            }

            if (dtoName == ConstAttachmentTypeCategory.User.ToString())
            {
                var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(attDto.entity.ToString());
                filter.UserID = entity.ID;
            }

            if (dtoName == ConstAttachmentTypeCategory.Session.ToString())
            {
                var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionDto>(attDto.entity.ToString());
                filter.SessionID = entity.ID;
            }

            var result =   await _uploadAppService.GetAllAttachmentsAsync(filter) ;
          
            return result ;
        }

        [HttpGet]
        [Route("GetAllAttachmentTypes/{categoryID}")]
        public async Task<ResultListDto> GetAllAttachmentTypesAsync(int categoryID)
        {           
            var result = await _uploadAppService.GetAllAttachmentTypesAsync(categoryID);
            return result;
        }

        [HttpPost]
        [Route("CheckAllFilesGetFromUser")]
        public async Task<List<string>> CheckAllFilesGetFromUserAsync([FromBody] AttachmentFilterDto filterDto)
        {
            var result = await _uploadAppService.CheckAllFilesGetFromUserAsync(filterDto);
            return result;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("sendUserImage")]
        public async Task<ResultObject> UploadUserImage([FromForm] ICollection<IFormFile> filess)
        {
            var resultobject = new ResultObject();

            var files = Request.Form.Files;
            string attachmentDto = Request.Form["attachmentDto"];
            AttachmentDto attDto = Newtonsoft.Json.JsonConvert.DeserializeObject<AttachmentDto>(attachmentDto);

            if (files.Any(f => f.Length == 0))
            {
                return new ResultObject { Result = attDto, ServerErrors = null /*new List<ServerErr>().Add(new ServerErr() { Hint = "هیچ فایلی فرستاده نشده است" })*/  };
            }
                attDto.Path = await _uploadAppService.CreateDirectoryAndFile(attDto.UserID.Value, "UserDto", files[0]);
           
            await _uploadAppService.RemoveAllPersonImages(attDto.UserID.Value);
            attDto.AttachmentTypeID = ConstAttachmentTypes.PersonImage;
            await _uploadAppService.CreateAttachmentAsync(attDto);

            resultobject.Result = attDto;
            resultobject.ServerErrors = null;
            return resultobject;
        }

    }

}
