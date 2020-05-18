using Consulting.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Core.Entities
{
    [Table("MilitaryServiceStatus", Schema = "Core")]
    public class MilitaryServiceStatus
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string MilitaryServiceStatusName { get; set; }

        [StringLength(25)]
        public string MilitaryServiceStatusCode { set; get; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string MilitaryServiceStatusDesc { get; set; }
    }
}
