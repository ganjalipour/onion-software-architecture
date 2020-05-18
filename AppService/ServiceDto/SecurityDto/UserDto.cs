using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Consulting.Common.Constants;
using Consulting.Common.Resources;
using Consulting.Common.Utility.Extentions;
using Consulting.Common.Utility.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    //[ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "UserDto")]
    public class UserDto
    {
        public UserDto()
        {
            ActivityDtos = new HashSet<ActivityDto>();
            UserBranches = new HashSet<UserBranchesDto>();
        }
        public int ID { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string UserName { get; set; }
        [Display(Name = "FirstName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string FirstName { get; set; }
        [Display(Name = "LastName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string LastName { get; set; }

        [Display(Name = "NationalCode", ResourceType = typeof(DataFields))]
        [CheckNationalCode]
        public string NationalCode { get; set; }

        [Display(Name = "Password", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [MinLength(8, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(maximumLength:50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Password { get; set; }

        [Display(Name = "RePassword", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [MinLength(8, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        [Compare("Password", ErrorMessageResourceName = "CompareField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(maximumLength:50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string RePassword { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(DataFields))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "DataType", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        //[DataType(DataType.Upload)]
        public IFormFile picture { get; set; }
        public bool IsRequireChangePass { get; set; }
        public int? FundsAccountID { get; set; }
        public int IssuerUserID { get; set; }
        public int IssuerBranchID { get; set; }

        public string UserStatusDesc
        {
            get
            {
                if (IsActive) return ConstIsActive.Active;
                else return ConstIsActive.Disable;
            }
        }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }


        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string PicturePath { get; set; }
        public bool IsConsultant { get; set; }
        public string Token { get; set; }
        public UserBranchesDto UserBranch { get; set; }
        public ICollection<ActivityDto> ActivityDtos { get; set; }
        public ICollection<UserBranchesDto> UserBranches { get; set; }
        public ICollection<UserBranchRoleDto> UserBranchRoles { get; set; }
    }
}
