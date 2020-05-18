using System.ComponentModel.DataAnnotations;
using Consulting.Common.Resources;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "PasswordDto")]

    public class PasswordDto
    {
        public int UserID { get; set; }

        [Display(Name = "Password", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Password { get; set; }

        [Display(Name = "NewPassword", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [MinLength(8, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string NewPassword { get; set; }
        public bool FromChangePassForm { get; set; }

        [Display(Name = "ReNewPassword", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [MinLength(8, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        [Compare("NewPassword", ErrorMessageResourceName = "CompareField", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ReNewPassword { get; set; }
    }
}
