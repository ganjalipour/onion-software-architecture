using Consulting.Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Customer.Entities
{
    [Table("EducationLevels", Schema = "Customer")]
    public class EducationLevels : Entity
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string EducationLevelsName { get; set; }
        public int EducationLevelsCode { get; set; }
        [StringLength(100)]
        public string EducationLevelsDesc { get; set; }
    }


}
