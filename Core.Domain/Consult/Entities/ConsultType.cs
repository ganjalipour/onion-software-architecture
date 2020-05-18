using Consulting.Common.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Consult.Entities
{
    [Table("ConsultType", Schema = "Consult")]
   public class ConsultType : Entity
    {
        public int ID { get; set; }
        public string ConsultTypeName { get; set; }
        public string ConsultTypeDesc { get; set; }
    }
}
