using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Consulting.Common.Resources;

namespace Consulting.Domains.Core.Entities
{
    [Table("Roles", Schema = "Core")]    
    public class Role : Entity
    {

        public Role()
        {
            UserBranchRoles = new HashSet<UserBranchRole>();

        }

        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string RoleName { get; set; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string RoleDesc { get; set; }
        public int Order { get; set; }
        public ICollection<UserBranchRole> UserBranchRoles { get; set; }
        public ICollection<RoleActivity> RoleActivity { get; set; }
    }
}
