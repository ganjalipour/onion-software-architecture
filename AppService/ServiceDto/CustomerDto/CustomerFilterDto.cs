using Consulting.Common.Dto;
using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Applications.AppService.ServiceDto.CustomerDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "CustomerFilterDto")]

    public class CustomerFilterDto : BaseFilterDto
    {

        public int ID { get; set; }

        public string FirstName { get; set; }

        //public int[] Branches { get; set; }

        public string LastName { get; set; }

        public string FatherName { set; get; }

        public DateTime BirthDate { get; set; }

        public string NationalCode { get; set; }

        public int? AccountStatusID { get; set; }

        public int? SeriChar { get; set; }

        public int? SeriNo { get; set; }

        public int? Serial { get; set; }

        public int? SSH { get; set; }

        public bool? IsMale { get; set; }

        public bool? IsMaried { get; set; }

        public int? CityID { get; set; }

        public int? CustomerGroupID { get; set; }

        public int? MilitaryServiceStatusID { get; set; }

        public int? NationalityID { get; set; }

        public int? LastEducationLevelID { get; set; }

        public string Job { get; set; }

        public int? Dependants { get; set; }

        public bool IsCompany { get; set; }

        public string CompanyName { get; set; }

        public int? EconomicCode { get; set; }

        public int? RegisterationCode { get; set; }

        public int? CityId { get; set; }

        public int? ProvinceId { get; set; }

        public int? VillageId { get; set; }

        public string BranchCode { get; set; }

    }
}
