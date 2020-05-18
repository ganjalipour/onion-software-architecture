using Consulting.Common.Model;
using Consulting.Common.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Entities
{
    [Table("Branches", Schema = "Core")]
    public class Branch : Entity
    {
        public Branch()
        {
            UserBranches = new HashSet<UserBranches>();
        }

        public int ID { get; set; }

        public int ZoneID { get; set; }

        //[Required]
        [StringLength(25)]
        public string BranchCode { get; set; }
        [StringLength(25)]
        public string OSTANCode { get; set; }

        public int Serial { get; set; }

        [Required]
        [StringLength(50)]
        public string BranchName { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(500)]
        [NotMapped]
        public string MasterAddress { get; set; }

        [StringLength(500)]
        public string MeetingAddress1 { get; set; }

        [StringLength(500)]
        public string MeetingAddress2 { get; set; }

        [StringLength(25)]
        public string PhoneNumber { get; set; }

        [StringLength(25)]
        public string Fax { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BranchHeadName { get; set; }

        [StringLength(25)]
        public string Latitude { get; set; }

        [StringLength(25)]
        public string Longitude { get; set; }

        public bool IsActive { get; set; }
        public int CustomerID { get; set; }

        [Description("شماره سپرده نزد بانک")]
        [StringLength(25)]
        public string BDN { get; set; }
        public virtual Zone Zone { get; set; }
        public ICollection<UserBranches> UserBranches { get; set; }
   
    }
}
