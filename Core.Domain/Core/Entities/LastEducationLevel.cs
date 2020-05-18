using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Consulting.Domains.Core.Core.Entities
{
    [Table("LastEducationLevel", Schema = "Core")]
    public class LastEducationLevel
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(20)]
        public string Code { set; get; }

        [StringLength(100)]
        public string Desc { get; set; }

    }
}
