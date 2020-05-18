using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Entities
{

    [Table("RoleActivities", Schema = "Core")]
    public class RoleActivity: Entity
    {
        [Key]
        public int ID { get; set; }
        public int ActivityID { get; set; }
        public Activity Activity { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
