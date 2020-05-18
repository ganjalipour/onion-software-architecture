using Consulting.Common.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Consult.Entities
{
    [Table("Comment", Schema = "Consult")]
   public class Comment : Entity
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string IssuerID { get; set; }
        public DateTime IssueDate { get; set; } 
    }
}
