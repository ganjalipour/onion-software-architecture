using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Customer.Entities
{
    [Table("CustomerDetailTypes", Schema = "Customer")]
    public class CustomerDetailType
    {
        public int ID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        public ICollection<CustomerDetail> CustomerDetails { get; set; }
    }
}
