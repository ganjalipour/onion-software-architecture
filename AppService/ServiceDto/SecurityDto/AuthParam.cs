using Consulting.Common.Resources;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "AuthParam")]

    public class AuthParam
    {
        [Display(Name = "UserName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string UserName { get; set; }

        [Display(Name = "Password", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Password { get; set; }

        //[Display(Name = "Password", ResourceType = typeof(DataFields))]
        //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string NewPassword { get; set; }

        [Display(Name = "BranchCode", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BranchCode { get; set; }
    }

}
