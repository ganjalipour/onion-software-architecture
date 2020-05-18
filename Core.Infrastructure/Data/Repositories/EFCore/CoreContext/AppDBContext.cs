using Consulting.Domains.Core.Consult.Entities;
using Consulting.Domains.Core.Core.Entities;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Customer.Entities;

using Microsoft.EntityFrameworkCore;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class AppDBContext : DbContext 
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }

        #region Core_Schema
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<UserBranches> UserBranches { get; set; }
        public virtual DbSet<UserBranchRole> UserBranchRoles { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<RoleActivity> RoleActivities { get; set; }

        #endregion Core_Schema

        #region Customer_Schema
        public virtual DbSet<CustomerDetailType> CustomerDetailTypes { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
        public virtual DbSet<CustomerHead> CustomerHeads { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<MilitaryServiceStatus> MilitaryServiceStatuses { get; set; }
        public virtual DbSet<EducationLevels> EducationLevels { get; set; }
        public virtual DbSet<CustomerSkill> CustomerSkills { get; set; }


        #endregion Customer_Schema


        #region Common
        public virtual DbSet<Attachment> Attachments { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<AttachmentType> AttachmentTypes { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<UserMessage> UserMessages { get; set; }

        public virtual DbSet<AttachmentTypeCategory> AttachmentTypeCategory { get; set; }

        #endregion


        #region Consult
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<Expertise> Expertises { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ConsultType> consultTypes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }



        #endregion Consult


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            RelationalModelBuilderExtensions.HasSequence<int>(modelbuilder, "TransactionSerialSequence", "Customer").StartsAt(1).IncrementsBy(1);
            RelationalModelBuilderExtensions.HasSequence<int>(modelbuilder, "CustomerHeadSerialSequence", "Customer").StartsAt(1).IncrementsBy(1);
            modelbuilder.Entity<CustomerHead>().Property(p => p.Serial).HasDefaultValueSql("NEXT VALUE FOR Customer.CustomerHeadSerialSequence");

         
            base.OnModelCreating(modelbuilder);
            #region ApplyConfiguration
            modelbuilder.ApplyConfiguration(new RoleConfiguration());
            modelbuilder.ApplyConfiguration(new UserConfiguration());
            modelbuilder.ApplyConfiguration(new UserBranchRoleConfiguration());
            modelbuilder.ApplyConfiguration(new UserBranchConfiguration());
            modelbuilder.ApplyConfiguration(new BranchConfiguration());
            modelbuilder.ApplyConfiguration(new ZoneConfiguration());
            modelbuilder.ApplyConfiguration(new ActivityConfiguration());
            modelbuilder.ApplyConfiguration(new RoleActivityConfiguration());
      
            modelbuilder.ApplyConfiguration(new CustomerDetailConfiguration());
            modelbuilder.ApplyConfiguration(new CustomerHeadConfiguration());
            modelbuilder.ApplyConfiguration(new CustomerDetailTypeConfiguration());
      
            modelbuilder.ApplyConfiguration(new NationalityConfiguration());
            modelbuilder.ApplyConfiguration(new MilitaryServiceStatusConfiguration());
            modelbuilder.ApplyConfiguration(new EducationalLevelsConfiguration());                      
                
            modelbuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelbuilder.ApplyConfiguration(new AttachmentTypeConfiguration());
            modelbuilder.ApplyConfiguration(new AttachmentTypeCategoryConfiguration());
            modelbuilder.ApplyConfiguration(new SkillConfiguration());
            modelbuilder.ApplyConfiguration(new CustomerSkillConfiguration());
            modelbuilder.ApplyConfiguration(new MessageConfiguration());
            modelbuilder.ApplyConfiguration(new UserMessageConfiguration());



            modelbuilder.ApplyConfiguration(new ConsultantConfiguration());
            modelbuilder.ApplyConfiguration(new ConsultConfiguration());
            modelbuilder.ApplyConfiguration(new CommentConfiguration());
            modelbuilder.ApplyConfiguration(new ConsultTypeConfiguration());
            modelbuilder.ApplyConfiguration(new QuestionConfiguration());
            modelbuilder.ApplyConfiguration(new ReplyConfiguration());

            #endregion ApplyConfiguration

        }
    }
}
