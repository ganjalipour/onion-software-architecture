using Consulting.Common.Model;
using Consulting.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Entities
{
    [Table("Messages", Schema = "Core")]
    public class Message: Entity
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Text { get; set; }

        public bool IsSeen { get; set; }

        public ICollection<UserMessage> UserMessages { get; set; }
    }
}
