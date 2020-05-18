using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Customer.Entities
{
    [Table("CustomerHeads", Schema = "Customer")]
    public class CustomerHead : Entity
    {
        public CustomerHead()
        {
            CustomerSkills = new List<CustomerSkill>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]

        public string LastName { get; set; }

        [StringLength(100)]

        public string FatherName { set; get; }

        public int CustomerUserID { get; set; }
        

        public DateTime BirthDate { get; set; }
        public int BranchID { get; set; }

        [StringLength(100)]
        public string BranchCode { get; set; }

        [StringLength(10)]
        public string SSH { get; set; }

        [StringLength(10)]

        public string NationalCode { get; set; }

        public int AccountStatusID { get; set; }

        public string SeriChar { get; set; }

        public int SeriNo { get; set; }

        public int Serial { get; set; }

        public bool IsMale { get; set; }

        public bool IsMaried { get; set; }

        public int CustomerGroupID { get; set; }//table

        public int MilitaryServiceStatusID { get; set; }//table

        public int NationalityID { get; set; }//table
        public int LastEducationLevelID { get; set; }//table

        [StringLength(100)]
        public string job { get; set; }

        public int Dependants { get; set; }

        public bool IsCompany { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public int EconomicCode { get; set; }

        public int RegisterationCode { get; set; }

        public ICollection<CustomerSkill> CustomerSkills { get; set; }

        public ICollection<CustomerDetail> CustomerDetails { get; set; }

        public EducationLevels EducationLevel { get; set; }

        public  ICollection<Attachment> Attachments { get; set; }

    }
}
