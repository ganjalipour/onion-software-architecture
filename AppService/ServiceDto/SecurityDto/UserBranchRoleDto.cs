
namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    public class UserBranchRoleDto
    {
        public int ID { get; set; }
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int RoleOrder { get; set; }
        public string RoleDesc { get; set; }
        public BranchDto Branch { get; set; }
        public RoleDto Role { get; set; }
    }
}
