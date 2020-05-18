using System.ComponentModel.DataAnnotations;

namespace Consulting.Applications.AppService.ServiceDto.CustomerDto
{
    public class EducationLevelsDto
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string EducationLevelsName { get; set; }
        public int EducationLevelsCode { get; set; }
        [StringLength(100)]
        public string EducationLevelsDesc { get; set; }
    }
}
