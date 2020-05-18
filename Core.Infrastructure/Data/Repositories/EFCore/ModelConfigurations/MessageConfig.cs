using Microsoft.EntityFrameworkCore;
using Consulting.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class MessageConfiguration : BaseEntityTypeConfiguration<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder) {
            builder.HasMany(x => x.UserMessages).WithOne(b => b.Message).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }

    public class UserMessageConfiguration : BaseEntityTypeConfiguration<UserMessage>
    {
        public override void Configure(EntityTypeBuilder<UserMessage> builder)
        {
            base.Configure(builder);
        }
    }


}
