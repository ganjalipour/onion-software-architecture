using Consulting.Common.Dto;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Applications.AppService.ServiceDto.BasicDto
{
    //[ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "KeyValueDto")]
    public class KeyValueDto:BaseFilter
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public string Code { get; set; }

        public int ParentID { get; set; }      
    }

}
