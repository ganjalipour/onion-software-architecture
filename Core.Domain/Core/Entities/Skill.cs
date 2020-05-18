using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Consulting.Common.Model;
using Consulting.Domains.Customer.Entities;

namespace Consulting.Domains.Core.Entities
{
    [Table("Skills", Schema = "Core")]
    public class Skill: Entity 
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string SkillTitle { get; set; }

        [StringLength(100)]
        public string SkillCode { set; get; }

        [StringLength(100)]
        public string SkillDesc { get; set; }

        public ICollection<CustomerSkill> CustomerSkills { get; set; }


    }

}
