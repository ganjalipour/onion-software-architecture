using Consulting.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Domains.Core.Service
{
    public class BranchFilter:BaseFilter
    {
        public string branchCode { get; set; }

        public string branchName { get; set; }
        
        public int CityId { get; set; }
        
        public int ProvinceId { get; set; }

        public int VillageId { get; set; }

        public string MeetingAddress1 { get; set; }

        public string MeetingAddress2 { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string BranchHeadName { get; set; }

        public string Address { get; set; }

        public int UserID { get; set; }

    }
}
