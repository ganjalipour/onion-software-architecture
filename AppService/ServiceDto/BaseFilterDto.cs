using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Common.Dto;
using System.Collections.Generic;

namespace Consulting.Applications.AppService.ServiceDto
{
    public class BaseFilterDto
    {
      
        public BaseFilterDto()
        {
           
        }
        public int pageNumber { get; set; }
        public int BranchID { get; set; }
        public IEnumerable<Sort> SortDto { get; set; }
        public List<int> Branches { get; set; }
        public UserBranchesDto UserBranchDto { get; set; }

        public bool IsLookUp { get; set; }
    }
}

