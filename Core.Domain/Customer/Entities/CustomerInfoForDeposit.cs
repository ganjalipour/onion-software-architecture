
namespace Consulting.Domains.Customer.Entities
{
    public class CustomerInfoForDeposit
    {
        public int DepositID { get; set; }

        public string DepositNumber { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerName { get; set; }

        public bool IsMale { get; set; }

        public string NationalCode { get; set; }
    }
}
