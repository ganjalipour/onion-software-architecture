using Consulting.Common.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Customer.Entities
{
    [NotMapped]
    public class GeneralStatisticsDAO : Entity
    {
        public int TotalCustomersCount { get; set; }

    }
}
