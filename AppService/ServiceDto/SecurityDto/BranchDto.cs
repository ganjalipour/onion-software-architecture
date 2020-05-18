using Consulting.Common.Resources;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "BranchDto")]

    public class BranchDto
    {
        public int ID { get; set; }

        [Display(Name = "BranchName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BranchName { get; set; }

        //[Display(Name = "BranchCode", ResourceType = typeof(DataFields))]
        //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BranchCode { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Address { get; set; }

        public string MasterAddress { get; set; }

        public bool IsActive { get; set; }

        public int? ProvinceId { get; set; }

        public int? CityId { get; set; }

        public int? VillageId { get; set; }

        public int? ZoneId { get; set; }

        public int DepositBankID { get; set; } //  شماره سپرده نزد صندوق

        [StringLength(500, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string MeetingAddress1 { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string MeetingAddress2 { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string PhoneNumber { get; set; }

        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Fax { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BranchHeadName { get; set; }

        public string BDN { get; set; }

        public int UserID { get; set; }

        [Display(Name = "Latitude", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int BranchCustomers { get; set; }
        public int BranceLoans { get; set; }
      //  public int 
    }
}
