using Consulting.Common.Model;
using Consulting.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Entities
{
    [Table("Activities", Schema = "Core")]
    public class Activity : Entity
    {
        public int Id { get; set; }
        
        public int ParentId { get; set; }
        
        public int Order { get; set; }
        
        public int Code { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Name { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Title { get; set; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Path { get; set; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Description { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string IconClass { get; set; }
        
        public bool IsActive { get; set; }

        public bool IsMenu { get; set; }

        public ICollection<RoleActivity> RoleActivity { get; set; }
    }
    
}
