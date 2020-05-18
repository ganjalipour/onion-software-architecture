using System.Collections.Generic;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.Sessions;
using Consulting.Common.Utility.Extentions;
using Consulting.Domains.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "SessionDto")]
    public class SessionDto
    {
        public SessionDto()
        {
            SessionUsers = new HashSet<SessionUsersDto>();
        }
        public int ID { get; set; }

        public ICollection<Attachment> Attachments { get; set; }

        public int BranchID { get; set; }

        //[Display(Name = "Desc", ResourceType = typeof(DataFields))]
        //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Desc { get; set; }

        //[Display(Name = "DateFa", ResourceType = typeof(DataFields))]
        //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]

        public string DateFa { get; set; }

        //[Display(Name = "Topic", ResourceType = typeof(DataFields))]
        //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]

        public string Topic { get; set; }

        public string PhoneNumber { get; set; }


        public string Message { get; set; }

        //[Display(Name = "Address", ResourceType = typeof(DataFields))]
        //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorMessages))]
        //[StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Address { get; set; }

        public bool Active { get; set; }

        public int SessionState { get; set; }

        public List<KeyValueDto> Users { get; set; }

        public List<int> Customers { get; set; }

        public ICollection<ApprovalDto> Approvals { get; set; }
        
        public ICollection<SessionUsersDto> SessionUsers { get; set; }
    }
}
