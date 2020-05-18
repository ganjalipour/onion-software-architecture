using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;
using Consulting.Domains.Core.Consult.Entities;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class ConsultantConfiguration : BaseEntityTypeConfiguration<Consultant>
    {
        public override void Configure(EntityTypeBuilder<Consultant> builder)
        {
            base.Configure(builder);
        }
    }


    public class ConsultConfiguration : BaseEntityTypeConfiguration<Expertise>
    {           
        public override void Configure(EntityTypeBuilder<Expertise> builder)
        {
            builder.HasData(new Expertise() { ID = 1, ExpertiseName = "HealthDoctors", ExpertiseDesc = "پزشکان سلامت" },
                new Expertise() { ID = 2, ExpertiseName = "Lawyers", ExpertiseDesc = "وکلای دادگستری" },
                new Expertise() { ID = 3, ExpertiseName = "Psychologist", ExpertiseDesc = "روانشناس" });
            base.Configure(builder);
        }
    }


    public class CommentConfiguration : BaseEntityTypeConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);
        }

    }

    public class ConsultTypeConfiguration : BaseEntityTypeConfiguration<ConsultType>
    {
        public override void Configure(EntityTypeBuilder<ConsultType> builder)
        {
            builder.HasData(new ConsultType() { ID = 1, ConsultTypeName = "Job", ConsultTypeDesc = "شغلی" },
                new ConsultType() { ID = 2, ConsultTypeName = "Educational", ConsultTypeDesc = "تحصیلی" },
                new ConsultType() { ID = 3, ConsultTypeName = "Family", ConsultTypeDesc = "خانواده" },
                new ConsultType() { ID = 4, ConsultTypeName = "Marriage", ConsultTypeDesc = "ازدواج" });
            base.Configure(builder);
        }

    }


    public class QuestionConfiguration : BaseEntityTypeConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);
        }

    }

    public class ReplyConfiguration : BaseEntityTypeConfiguration<Reply>
    {
        public override void Configure(EntityTypeBuilder<Reply> builder)
        {
            base.Configure(builder);
        }

    }

}
