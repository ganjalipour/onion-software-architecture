using Consulting.Common.Dto;

namespace Consulting.Domains.Core.Service
{
    public class UserFilter : BaseFilter
    {
        public int UserID { get; set; }
        public bool IsUserRequest { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
    }
}
