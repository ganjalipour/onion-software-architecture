using Consulting.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Consulting.Applications.AppService.AuthAppService;
using Microsoft.AspNetCore.Mvc;
using Consulting.Common.Utility.Extentions;
using Consulting.Applications.AppService.ServiceDto.FileUploadDto;

namespace Consulting.Applications.AppService.ServiceDto.CustomerDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "CustomerHeadDto")]

    public class CustomerHeadDto
    {
        public CustomerHeadDto()
        {
            MobileCustomerDetail = new CustomerDetailDto();
            HomeAddressCustomerDetail = new CustomerDetailDto();
            HomePhoneCustomerDetail = new CustomerDetailDto();
            WorkPhoneCustomerDetail = new CustomerDetailDto();
            WorkAddressCustomerDetail = new CustomerDetailDto();
            CertificateImageCustomerDetail = new CustomerDetailDto();
            PersonalImageCustomerDetail = new CustomerDetailDto();
            SignatureImageCustomerDetail = new CustomerDetailDto();
            CustomerSkills = new List<CustomerSkillDto>();
            EducationLevel = new EducationLevelsDto();
            Skills = new List<int>();
        }
        public int ID { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(maximumLength: 50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(maximumLength: 50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string LastName { get; set; }


        [Display(Name = "FatherName", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(maximumLength: 50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string FatherName { set; get; }

        //[Display(Name = "BirthDate", ResourceType = typeof(DataFields))]
        //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[DataType(DataType.DateTime, ErrorMessageResourceName = "DateTime", ErrorMessageResourceType = typeof(ErrorMessages))]
        //public DateTime BirthDate { get; set; }

        [Display(Name = "SSH", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(10, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string SSH { get; set; }

        [Display(Name = "BirthDateFa", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[MinLength(10, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[StringLength(10, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BirthDateFa { get; set; }


        public DateTime? BirthDateEn { get; set; }

        [Display(Name = "NationalCode", ResourceType = typeof(DataFields))]
        public string NationalCode { get; set; }

        [Display(Name = "SeriChar", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string SeriChar { get; set; }
        public string BranchName { get; set; }
        public ZoneDto Zone { get; set; }

        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string SeriNo { get; set; }

        //[StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public int Serial { get; set; }

        public bool IsMale { get; set; }

        public bool IsMaried { get; set; }

        public int BranchID { get; set; }

        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string BranchCode { get; set; }

        [Display(Name = "MilitaryServiceStatus", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        public int MilitaryServiceStatusID { get; set; }


        [Display(Name = "Nationality", ResourceType = typeof(DataFields))]
        [CustomNumberValidate(1, ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        public int NationalityID { get; set; }

        [Display(Name = "LastEducationLevel", ResourceType = typeof(DataFields))]
        [CustomNumberValidate(1, ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        public int LastEducationLevelID { get; set; }

        [Display(Name = "job", ResourceType = typeof(DataFields))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string job { get; set; }

        public bool IsCompany { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string CompanyName { get; set; }

        public int EconomicCode { get; set; }

        public int RegisterationCode { get; set; }

       //public ICollection<DepositDto> Deposits { get; set; }


        public List<CustomerDetailDto> CustomerDetails { get; set;}

        public List<CustomerSkillDto> CustomerSkills { get; set; }

        

        public IList<int> Skills { get; set; }


        public CustomerDetailDto MobileCustomerDetail { get; set; }


      
        public CustomerDetailDto HomeAddressCustomerDetail { get; set; }


        public CustomerDetailDto WorkAddressCustomerDetail { get; set; }


        public CustomerDetailDto WorkPhoneCustomerDetail { get; set; }

      
        public CustomerDetailDto HomePhoneCustomerDetail { get; set; }

        
        public CustomerDetailDto CertificateImageCustomerDetail { get; set; }

        public CustomerDetailDto PersonalImageCustomerDetail { get; set; }

        public CustomerDetailDto SignatureImageCustomerDetail { get; set; }
        public EducationLevelsDto EducationLevel { get; set; }
        public ICollection<AttachmentDto> Attachments { get; set; }



        public void FillCustomerDetail( )
        {
            CustomerDetails = new List<CustomerDetailDto>();

            if(MobileCustomerDetail != null && !string.IsNullOrEmpty(MobileCustomerDetail.Value) )
             CustomerDetails.Add(new CustomerDetailDto() { ID = MobileCustomerDetail.ID 
            ,Value = MobileCustomerDetail.Value, CustomerDetailTypeID = MobileCustomerDetail.CustomerDetailTypeID ,CustomerHeadID =ID });

            if (HomeAddressCustomerDetail != null && !string.IsNullOrEmpty(HomeAddressCustomerDetail.Value))
                CustomerDetails.Add(new CustomerDetailDto() { ID = HomeAddressCustomerDetail.ID, Value = HomeAddressCustomerDetail.Value, CustomerDetailTypeID = HomeAddressCustomerDetail.CustomerDetailTypeID, CustomerHeadID = ID });

            if (HomePhoneCustomerDetail != null && !string.IsNullOrEmpty(HomePhoneCustomerDetail.Value))
                CustomerDetails.Add(new CustomerDetailDto() { ID = HomePhoneCustomerDetail.ID, Value = HomePhoneCustomerDetail.Value, CustomerDetailTypeID = HomePhoneCustomerDetail.CustomerDetailTypeID, CustomerHeadID = ID });

            if (CertificateImageCustomerDetail != null && !string.IsNullOrEmpty(CertificateImageCustomerDetail.Value))
                CustomerDetails.Add(new CustomerDetailDto() { ID = CertificateImageCustomerDetail.ID, Value = CertificateImageCustomerDetail.Value, CustomerDetailTypeID = CertificateImageCustomerDetail.CustomerDetailTypeID, CustomerHeadID = ID });

            if (PersonalImageCustomerDetail != null && !string.IsNullOrEmpty(PersonalImageCustomerDetail.Value))
                CustomerDetails.Add(new CustomerDetailDto() { ID = PersonalImageCustomerDetail.ID, Value = PersonalImageCustomerDetail.Value, CustomerDetailTypeID = PersonalImageCustomerDetail.CustomerDetailTypeID, CustomerHeadID = ID });

            if (SignatureImageCustomerDetail != null && !string.IsNullOrEmpty(SignatureImageCustomerDetail.Value))
                CustomerDetails.Add(new CustomerDetailDto() { ID = SignatureImageCustomerDetail.ID, Value = SignatureImageCustomerDetail.Value, CustomerDetailTypeID = SignatureImageCustomerDetail.CustomerDetailTypeID, CustomerHeadID = ID });

            if (WorkAddressCustomerDetail != null && !string.IsNullOrEmpty(WorkAddressCustomerDetail.Value))
                CustomerDetails.Add(new CustomerDetailDto() { ID = WorkAddressCustomerDetail.ID, Value = WorkAddressCustomerDetail.Value, CustomerDetailTypeID = WorkAddressCustomerDetail.CustomerDetailTypeID, CustomerHeadID = ID });

            if (WorkPhoneCustomerDetail != null && !string.IsNullOrEmpty(WorkPhoneCustomerDetail.Value))
                CustomerDetails.Add(new CustomerDetailDto() { ID = WorkPhoneCustomerDetail.ID, Value = WorkPhoneCustomerDetail.Value, CustomerDetailTypeID = WorkPhoneCustomerDetail.CustomerDetailTypeID, CustomerHeadID = ID });
        }

    }

}

