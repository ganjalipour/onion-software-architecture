using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Consulting.Common.Resources;

namespace Consulting.Applications.AppService.ServiceDto.BasicDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "BankDto")]
    public class BankDto
    {
        public int Id { get; set; }

        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BankName { get; set; }

        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BankType { get; set; }

        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BankCode { get; set; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BankDesc { get; set; }
    }
}
