using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Consult.Entities
{
    [Table("Question", Schema = "Consult")]
    public class Question: Entity
    {
        public int ID { get; set; }
        public int IssueUserID { get; set; }
        public string Content { get; set; }
        public DateTime IssuerDate { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
