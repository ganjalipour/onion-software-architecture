using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Common.Dto
{
    public class BaseFilter
    {
        public int PageNumber { get; set; }
        public ICollection<Sort> SortDto { get; set; }
        public int[] Branches { get; set; }
        public int BranchID { get; set; }
        public bool IsLookUp { get; set; }
    }
}
