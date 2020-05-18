using Consulting.Common.Model;
using Consulting.Common.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Entities
{
    [Table("Zones", Schema = "Core")]
    public class Zone : Entity
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ZoneName { get; set; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ZoneDesc { get; set; }

        public ICollection<Branch> Branches { get; set; }

        [StringLength(20)]
        public string OSTAN { get; set; }

        [StringLength(25)]
        public string OSTANCode { get; set; }


        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string OstanName { get; set; }

        [StringLength(20)]
        public string SHAHRESTAN { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ShahrestName { get; set; }

        [StringLength(20)]
        public string BAKHSH { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BakhshName { get; set; }

        [StringLength(20)]
        public string Dehestan { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string DehestanName { get; set; }

        [StringLength(20)]
        public string Abadi { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string AbadiName { get; set; }

    }
}
