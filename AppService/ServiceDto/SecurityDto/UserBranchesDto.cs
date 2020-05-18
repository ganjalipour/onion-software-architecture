
namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    public class UserBranchesDto
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public BranchDto Branch { get; set; }
        public UserDto User { get; set; }
    }
}
