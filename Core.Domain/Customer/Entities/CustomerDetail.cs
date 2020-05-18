using Consulting.Common.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Customer.Entities
{
    [Table("CustomerDetails", Schema = "Customer")]
    public class CustomerDetail : Entity
    {
        [Key]
        public int ID { get; set; }
        public int CustomerHeadID { get; set; }
        public int CustomerDetailTypeID { get; set; }
        [StringLength(500)]
        public string Value { get; set; }
        public virtual CustomerHead CustomerHead { get; set; }
        public virtual CustomerDetailType CustomerDetailType { get; set; }
    }
}
