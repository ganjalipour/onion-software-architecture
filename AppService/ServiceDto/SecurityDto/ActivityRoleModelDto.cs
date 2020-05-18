using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using Consulting.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "ActivityRoleModelDto")]

    public class ActivityRoleModelDto
    {
        public int ActivityID { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Title { get; set; }

        public int RoleID { get; set; }
        public int? RoleActivitiyID { get; set; }
        public bool HasAccess { get; set; }
    }
}
