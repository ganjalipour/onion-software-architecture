using Consulting.Common.Dto;
using Consulting.Domains.Core.Core.Entities;
namespace Consulting.Domains.Core.Service
{
    public class AttachmentFilter:BaseFilter
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public int SessionID { get; set; }

        public AttachmentType AttachmentType { get; set; }

        public int AttachmentTypeID { get; set; }

        public bool WithPaging { get; set; }
    }
}
