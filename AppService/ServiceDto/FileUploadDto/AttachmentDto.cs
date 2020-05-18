using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Common.Resources;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Consulting.Applications.AppService.ServiceDto.FileUploadDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "AttachmentDto")]

    public class AttachmentDto
    {
        public int ID { get; set; }

        public IFormFile File { get; set; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Desc { get; set; }
      
        public string FileType { get; set; }

        public Object entity { get; set; }
        public int? UserID { get; set; }

        public int? LoanID { get; set; }

        public int? CustomerHeadID { get; set; }
        

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Path { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string FileName { get; set; }

        public int AttachmentTypeID { get; set; }

        public KeyValueDto AttachmentType { get; set; }

    }

}
