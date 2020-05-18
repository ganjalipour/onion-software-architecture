using Consulting.Common.Model;
using Consulting.Domains.Core.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Entities
{
    [Table("Attachments", Schema = "Core")]
    public class Attachment: Entity
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string Desc { get; set; }

        [StringLength(100)]
        public string Path { get; set; }

        [StringLength(100)]
        public string FileType { get; set; }

        public int? UserID { get; set; }

        public int? CustomerHeadID { get; set; }

        public int? SessionID { get; set; }


        public int AttachmentTypeID { get; set; }

        public AttachmentType AttachmentType { get; set; }

    }


}
