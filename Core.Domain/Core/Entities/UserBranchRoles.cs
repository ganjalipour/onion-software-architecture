using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Consulting.Domains.Core.Entities
{
    [Table("UserBranchRoles", Schema = "Core")]
    public class UserBranchRole : Entity
    {
        [Key,Column("UserBranchRoleID")]
        public int ID { get; set; }


        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public Branch Branch { get; set; }

        public  Role Role { get; set; }
        public   User User { get; set; }
    }
}
