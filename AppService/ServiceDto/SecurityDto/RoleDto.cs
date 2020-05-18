using Consulting.Common.Resources;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "RoleDto")]

    public class RoleDto
    {
        public int ID { get; set; }

        [Display(Name = "RoleName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string RoleName { get; set; }

        [Display(Name = "RoleDesc", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string RoleDesc { get; set; }
    }
}
