using Consulting.Common.Dto;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "SessionFilterDto")]

    public class SessionFilterDto : BaseFilterDto
    {

        public int SessionID { get; set; }

        public string Desc { get; set; }

        public string DateFa { get; set; }

        public string Topic { get; set; }

        public string Address { get; set; }

    }
}
