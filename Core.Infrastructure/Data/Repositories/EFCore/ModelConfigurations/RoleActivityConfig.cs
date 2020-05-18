using Consulting.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;
using static Consulting.Common.Constants.ConstActivities;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class RoleActivityConfiguration : BaseEntityTypeConfiguration<RoleActivity>
    {
        public override void Configure(EntityTypeBuilder<RoleActivity> builder)
        {
            builder.HasIndex(r => r.ID).IsUnique(true);
            builder.HasIndex(a => new { a.ActivityID, a.RoleID }).IsUnique(true);

            builder.HasData(new RoleActivity { ID = 1, ActivityID = dashboard, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 2, ActivityID = SecurityMenuRoot, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 3, ActivityID = userManagement, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 4, ActivityID = branchesManagement, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 5, ActivityID = changePassword, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 6, ActivityID = roleManagement, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 7, ActivityID = CustomerMenuRoot, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 8, ActivityID = CustomerManagement, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 9, ActivityID = WaitingPage, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 10, ActivityID = Sessions, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 11, ActivityID = MessagesManagement, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 12, ActivityID = SessionsManagement, RoleID = 1 });
            builder.HasData(new RoleActivity { ID = 13, ActivityID = ExitMenu, RoleID = 1 });

            base.Configure(builder);
        }
    }
}
