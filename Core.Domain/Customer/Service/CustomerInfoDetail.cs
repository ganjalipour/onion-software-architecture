using System.ComponentModel.DataAnnotations;

namespace Consulting.Domains.Core.Customer.Service
{
  public  class CustomerInfoDetail
    {
        [StringLength(25)]
        public string Mobile { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(250)]
        public string PersonalImage { get; set; }

        [StringLength(250)]
        public string CertificateImage { get; set; }
    }
}
