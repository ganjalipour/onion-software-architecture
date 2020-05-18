using Microsoft.EntityFrameworkCore;
using Consulting.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;
using Consulting.Domains.Core.Core.Entities;
using Consulting.Domains.Customer.Entities;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class CustomerHeadConfiguration : BaseEntityTypeConfiguration<CustomerHead>
    {           
        public override void Configure(EntityTypeBuilder<CustomerHead> builder)
        {                         
            builder.HasMany(d => d.CustomerDetails)
                 .WithOne(p => p.CustomerHead).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(u => u.NationalCode).IsUnique(true);
            base.Configure(builder);
        }
    }


    public class NationalityConfiguration : BaseEntityTypeConfiguration<Nationality>
    {
        public override void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.HasData(new Nationality() {ID=1 ,NationalityName = "Irani"  , NationalityDesc ="ایرانی"});
            builder.HasData(new Nationality() { ID = 2, NationalityName = "Khareji" , NationalityDesc = "خارجی" });
            base.Configure(builder);
        }
    }


    public class SkillConfiguration : BaseEntityTypeConfiguration<Skill>
    {
        public override void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasData(new Skill() { ID = 1, SkillDesc= "نجاری" });
            builder.HasData(new Skill() { ID = 2, SkillDesc = "آشپزی" });
            builder.HasData(new Skill() { ID = 3, SkillDesc = "خیاطی" });
            builder.HasData(new Skill() { ID = 4, SkillDesc = "برنامه نویس" });
            base.Configure(builder);
        }
    }


    public class CustomerSkillConfiguration : BaseEntityTypeConfiguration<CustomerSkill>
    {
        public override void Configure(EntityTypeBuilder<CustomerSkill> builder)
        {
                       base.Configure(builder);
        }
    }


    public class MilitaryServiceStatusConfiguration : BaseEntityTypeConfiguration<MilitaryServiceStatus>
    {
        public override void Configure(EntityTypeBuilder<MilitaryServiceStatus> builder)
        {
           
            builder.HasData(new MilitaryServiceStatus() { ID = 1,MilitaryServiceStatusDesc = "معاف" , MilitaryServiceStatusName = "Exempt" });
            builder.HasData(new MilitaryServiceStatus() { ID = 2, MilitaryServiceStatusDesc = "معاف پزشکی" , MilitaryServiceStatusName = "Exempt" });
            builder.HasData(new MilitaryServiceStatus() { ID = 3, MilitaryServiceStatusDesc = "درحال خدمت" , MilitaryServiceStatusName = "Serving" });
            base.Configure(builder);
        }
    }

    public class EducationalLevelsConfiguration : BaseEntityTypeConfiguration<EducationLevels>
    {
        public override void Configure(EntityTypeBuilder<EducationLevels> builder)
        {
            builder.HasData(new EducationLevels() { ID = 1, EducationLevelsDesc = "کارشناسی" ,EducationLevelsName = "Bsc" });
            builder.HasData(new EducationLevels() { ID = 2, EducationLevelsDesc = "کارشناسی ارشد" , EducationLevelsName = "Masters" });
            builder.HasData(new EducationLevels() { ID = 3, EducationLevelsDesc = "دکترا و بالاتر" , EducationLevelsName = "Doctoral" });
            builder.HasData(new EducationLevels() { ID = 4, EducationLevelsDesc = "دیپلم", EducationLevelsName = "diploma" });
            builder.HasData(new EducationLevels() { ID = 5, EducationLevelsDesc = "زیر دیپلم", EducationLevelsName = "underdiploma" });
            builder.HasData(new EducationLevels() { ID = 6, EducationLevelsDesc = "فوق دیپلم", EducationLevelsName = "upperdiploma" });
            builder.HasData(new EducationLevels() { ID = 7, EducationLevelsDesc = " بی سواد", EducationLevelsName = "nonEducation" });
            base.Configure(builder);
        }
    }

    public class CustomerDetailConfiguration : BaseEntityTypeConfiguration<CustomerDetail>
    {
        public override void Configure(EntityTypeBuilder<CustomerDetail> builder)
        {
            base.Configure(builder);
        }
    }

    public class CustomerDetailTypeConfiguration : BaseEntityTypeConfiguration<CustomerDetailType>
    {
        public override void Configure(EntityTypeBuilder<CustomerDetailType> builder)
        {
            builder.HasData(new CustomerDetailType { ID = 1, Name = "Mobile", Code = "موبایل" });
            builder.HasData(new CustomerDetailType { ID = 2, Name = "phone", Code = "تلفن" });
            builder.HasData(new CustomerDetailType { ID = 3, Name = "Address", Code = "آدرس" });
            builder.HasData(new CustomerDetailType { ID = 4, Name = "CertificateImage", Code = "عکس شناسنامه" });
            builder.HasData(new CustomerDetailType { ID = 5, Name = "PersonalImage", Code = "عکس پرسنلی" });
            builder.HasData(new CustomerDetailType { ID = 6, Name = "SignatureImage", Code = "عکس امضا" });
            base.Configure(builder);
        }
    }
}
