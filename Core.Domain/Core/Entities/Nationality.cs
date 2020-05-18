using Consulting.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Core.Entities
{
    [Table("Nationality", Schema = "Core")]
    public class Nationality
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string NationalityName { get; set; }

        [StringLength(20)]
        public string NationalityCode { set; get; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string NationalityDesc { get; set; }
    }
}
