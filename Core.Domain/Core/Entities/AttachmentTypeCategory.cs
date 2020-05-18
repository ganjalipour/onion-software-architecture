using Consulting.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Core.Entities
{
    [Table("AttachmentTypeCategories", Schema = "Core")]
    public class AttachmentTypeCategory
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string AttachmentTypeCategoryName { get; set; }

        public int AttachmentTypeCategoryCode { set; get; }

        public int AttachmentTypeCategoryID { get; set; }

        [StringLength(250, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string AttachmentTypeCategoryDesc { get; set; }

        public ICollection<AttachmentType> AttachmentTypes { get; set; }

    }
}
