using Consulting.Common.Model;
using Consulting.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Entities
{
    [Table("UserMessages", Schema = "Core")]
    public class UserMessage: Entity
    {
        [Key, Column("UserMessageID")]
        public int ID { get; set; }

        public int? SenderUserID { get; set; }

        public int? ReceiverUserID { get; set; }

        [ForeignKey("Message")]
        public int MessageID { get; set; }

        public Message Message { get; set; }

        public User SenderUser { get; set; }

        public User ReceiverUser { get; set; }

    }
}
