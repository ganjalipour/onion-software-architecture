using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Common.Dto;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Applications.AppService.ServiceDto.FileUploadDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "AttachmentFilterDto")]

    public class AttachmentFilterDto : BaseFilterDto
    {
        public AttachmentFilterDto()
        {
            this.WithPaging = true;
        }
        public int ID { get; set; }

        public int LoanID { get; set; }

        public int CustomerID { get; set; }

        public int CategoryID { get; set; }

        public int UserID { get; set; }

        public int SessionID { get; set; }

        public KeyValueDto AttachmentType { get; set; }

        public bool WithPaging { get; set; }

    }
}
