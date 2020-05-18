using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Consulting.Domains.Core.Entities
{
    [Table("UserBranches", Schema = "Core")]
    public  class UserBranches : Entity
    {
        [Key,Column("UserBranchID")]
        public int ID { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public Branch Branch { get; set; }

        public User User { get; set; }
    }
}
