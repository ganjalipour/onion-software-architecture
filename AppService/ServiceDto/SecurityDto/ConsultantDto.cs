using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "ConsultantDto")]

    public class ConsultantDto
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ConsultTypeID { get; set; }
        public string ConsultTypeDesc { get; set; }
        public UserDto User { get; set; }
    }
}
