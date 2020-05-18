using Consulting.Common.Resources;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Consulting.Applications.AppService.ServiceDto.CustomerDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "CustomerDetailDto")]

    public class CustomerDetailDto
    {
        public CustomerDetailDto()
        {
         
        }
        public int ID { get; set; }

        [Display(Name = "Code", ResourceType = typeof(DataFields))]
        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Code { get; set; }

        [Display(Name = "Value", ResourceType = typeof(DataFields))]
        [StringLength(500, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Value { get; set; }
        
        public int CustomerHeadID { get; set; }
        
        public int CustomerDetailTypeID { get; set; }
    }
}
