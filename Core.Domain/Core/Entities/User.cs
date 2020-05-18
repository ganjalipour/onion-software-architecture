using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consulting.Domains.Core.Entities
{
    [Table("Users", Schema = "Core")]
    public class User : Entity
    {
        public User()
        {
            UserBranchRoles = new HashSet<UserBranchRole>();
            UserBranches = new List<UserBranches>();
        }
        public int ID { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string NationalCode { get; set; }

        [StringLength(128)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(100)]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsRequireChangePass { get; set; }

        public int ConfirmCode { get; set; }

        [NotMapped]
        public int? FundsAccountID { get; set; }
        public ICollection<UserBranches> UserBranches { get; set; }

        [InverseProperty("SenderUser")]
        public ICollection<UserMessage> SenderUserMessages { get; set; }


        [InverseProperty("ReceiverUser")]
        public ICollection<UserMessage> ReceiverUserMessages { get; set; }

        public virtual ICollection<UserBranchRole> UserBranchRoles { get; set; }
    }
}
