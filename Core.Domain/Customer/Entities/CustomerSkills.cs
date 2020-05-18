using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Customer.Entities
{
        [Table("CustomerSkills", Schema = "Customer")]
        public class CustomerSkill: Entity
        {
            [Key, Column("CustomerSkillID")]
            public int ID { get; set; }

            [ForeignKey("CustomerHead")]
            public int CustomerID { get; set; }

            [ForeignKey("Skill")]
            public int SkillID { get; set; }

            public CustomerHead CustomerHead{ get; set; }

            public Skill Skill{ get; set; }
        }
    
}
