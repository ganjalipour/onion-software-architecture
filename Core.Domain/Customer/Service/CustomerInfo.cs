using Consulting.Domains.Customer.Entities;
using System;
using System.Collections.Generic;

namespace Consulting.Domains.Customer.Service
{
    public class CustomerInfo
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { set; get; }

        public DateTime BirthDate { get; set; }

        public int SSH { get; set; }

        public int NationalCode { get; set; }

        public int AccountStatusID { get; set; }

        public int SeriChar { get; set; }

        public int SeriNo { get; set; }

        public int Serial { get; set; }

        public bool IsMale { get; set; }

        public bool IsMaried { get; set; }

        public int CityID { get; set; }

        public int CustomerGroupID { get; set; }

        public int MilitaryServiceStatusID { get; set; }

        public int NationalityID { get; set; }

        public int LastEducationLevelID { get; set; }

        public string job { get; set; }

        public int Dependants { get; set; }

        public bool IsCompany { get; set; }

        public string CompanyName { get; set; }

        public int EconomicCode { get; set; }

        public int RegisterationCode { get; set; }

        public List<CustomerDetail> CustomerDetails { get; set; }

    }

}
