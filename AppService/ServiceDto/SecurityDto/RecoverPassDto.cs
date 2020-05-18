
namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
  public class RecoverPassDto
    {
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int ConfirmCode { get; set; }
    }
}
