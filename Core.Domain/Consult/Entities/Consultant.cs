using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Consult.Entities
{
    [Table("Consultant", Schema = "Consult")]
    public class Consultant: Entity
    {
        public Consultant()
        {
            Expertises = new HashSet<Expertise>();
        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ConsultTypeID { get; set; }
        public ICollection<Expertise> Expertises { get; set; }
        public User User { get; set; }
        public ConsultType ConsultType { get; set; }


    }
}
