using Consulting.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;
using Consulting.Domains.Core.Core.Entities;
using Consulting.Common.Constants;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class AttachmentConfiguration : BaseEntityTypeConfiguration<Attachment>
    {
        public override void Configure(EntityTypeBuilder<Attachment> builder) {
           
            base.Configure(builder);
        }
    }

    public class AttachmentTypeConfiguration : BaseEntityTypeConfiguration<AttachmentType>
    {
        public override void Configure(EntityTypeBuilder<AttachmentType> builder)
        {
            builder.HasData( new AttachmentType() { ID = ConstAttachmentTypes.BirthCertificateImage, IsRequierd = true, AttachmentTypeCode = 1112, AttachmentTypeDesc = "عکس شناسنامه", AttachmentTypeCategoryID = ConstAttachmentTypeCategory.Customer },
            new AttachmentType() { ID = ConstAttachmentTypes.NationalIdImage, AttachmentTypeCode = 11121, IsRequierd = true, AttachmentTypeDesc = "کارت ملی", AttachmentTypeCategoryID = ConstAttachmentTypeCategory.Customer },
            new AttachmentType() { ID = ConstAttachmentTypes.CardService, AttachmentTypeCode = 11122, IsRequierd = false, AttachmentTypeDesc = "کارت پایان خدمت", AttachmentTypeCategoryID = ConstAttachmentTypeCategory.Customer },
            new AttachmentType() { ID = ConstAttachmentTypes.EducationDegree, AttachmentTypeCode = 11123, IsRequierd = false, AttachmentTypeDesc = "مدرک تحصیلی", AttachmentTypeCategoryID = ConstAttachmentTypeCategory.Customer },
            new AttachmentType() { ID = ConstAttachmentTypes.Passport, AttachmentTypeCode = 11128, IsRequierd = false, AttachmentTypeDesc = "گذر نامه", AttachmentTypeCategoryID = ConstAttachmentTypeCategory.Customer },
              new AttachmentType() { ID = ConstAttachmentTypes.PersonImage, AttachmentTypeCode = 11130, IsRequierd = false, AttachmentTypeDesc = " عکس کاربری", AttachmentTypeCategoryID = ConstAttachmentTypeCategory.User });


          base.Configure(builder);
        }
    }

    public class AttachmentTypeCategoryConfiguration : BaseEntityTypeConfiguration<AttachmentTypeCategory>
    {
        public override void Configure(EntityTypeBuilder<AttachmentTypeCategory> builder)
        {
            builder.HasData(
             new AttachmentTypeCategory() { ID = ConstAttachmentTypeCategory.Customer, AttachmentTypeCategoryCode = 1, AttachmentTypeCategoryDesc = "مشتریان" },
             new AttachmentTypeCategory() { ID = ConstAttachmentTypeCategory.User, AttachmentTypeCategoryCode = 2, AttachmentTypeCategoryDesc = "کاربران" });
            base.Configure(builder);
        }
    }


}
