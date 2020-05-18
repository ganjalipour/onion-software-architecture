using Consulting.Common.Resources;
using Consulting.Common.Utility.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Http.ModelBinding;

namespace Consulting.Applications.AppService.ServiceDto.CustomerDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "ZoneDto")]

    public class ZoneDto
    {
        public int ID { get; set; }

        //public int ParentId { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ZoneName { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ZoneDesc { get; set; }

        public int? ProvinceID { get; set; }
        public int? CityID { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string OSTAN { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string OstanName { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string SHAHRESTAN { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ShahrestName { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string AbadiName { get; set; }


    }
}
