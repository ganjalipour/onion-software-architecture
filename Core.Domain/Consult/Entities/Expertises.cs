using Consulting.Common.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Consult.Entities
{
    [Table("Expertise", Schema = "Consult")]
    public class Expertise : Entity
    {
        public int ID { get; set; }
        public string ExpertiseName { get; set; }
        public string ExpertiseDesc { get; set; }
    }
}
