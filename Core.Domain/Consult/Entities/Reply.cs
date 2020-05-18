using Consulting.Common.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Consult.Entities
{
    [Table("Reply", Schema = "Consult")]
    public class Reply: Entity
    {
        public int ID { get; set; }
        public int IssueUserID { get; set; }
        public string Content { get; set; }
        public DateTime IssuerDate { get; set; }
    }
}
