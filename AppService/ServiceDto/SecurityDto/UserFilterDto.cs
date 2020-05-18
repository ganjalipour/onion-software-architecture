using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;


namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "UserFilterDto")]

    public class UserFilterDto : BaseFilterDto
    {
        public int UserID { get; set; }
        public bool IsUserRequest { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        //public int[] Branches { get; set; }
    }
}
