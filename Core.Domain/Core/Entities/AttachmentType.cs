using Consulting.Common.Resources;
using Consulting.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Core.Entities
{
    [Table("AttachmentTypes", Schema = "Core")]
    public class AttachmentType
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string AttachmentTypeName { get; set; }

        public int AttachmentTypeCode { set; get; }

        public int AttachmentTypeCategoryID { get; set; }

        public bool IsRequierd { get; set; }

        public AttachmentTypeCategory AttachmentTypeCategory { get; set; }

        [StringLength(100)]
        public string AttachmentTypeDesc { get; set; }

        //public ICollection<Attachment> Attachments { get; set; }
    }
}
