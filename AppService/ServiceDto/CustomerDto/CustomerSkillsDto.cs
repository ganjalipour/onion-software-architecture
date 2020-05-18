using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Applications.AppService.ServiceDto.CustomerDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "CustomerSkillDto")]

    public class CustomerSkillDto
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public int SkillID { get; set; }

    }

}
