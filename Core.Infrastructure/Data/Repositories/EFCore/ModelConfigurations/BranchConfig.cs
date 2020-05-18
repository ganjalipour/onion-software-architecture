using Microsoft.EntityFrameworkCore;
using Consulting.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class BranchConfiguration : BaseEntityTypeConfiguration<Branch>
    {           
        public override void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasMany(p => p.UserBranches).WithOne(p => p.Branch).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new Branch
            {
                ID = 1,
                BranchName = "تست",
                BranchCode = "380001",
                ZoneID = 5,
                IsActive = true,
                OSTANCode = "38",
                Serial = 1,
                PhoneNumber = "09149686690"
            });
            base.Configure(builder);
        }
    }
}
