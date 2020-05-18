using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Consulting.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;
using Consulting.Common.Constants;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class RoleConfiguration : BaseEntityTypeConfiguration<Role>
    {
      
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(u => u.RoleName).IsUnique(true);
            builder.HasData(new Role { ID = 1, RoleName = "Administrator", Order = ConstRolesOrder.Admin, RoleDesc="مدیرارشد"});
            builder.HasData(new Role { ID = 2, RoleName = "Supervisor", Order = ConstRolesOrder.Supervisor, RoleDesc = "رئیس دفتر" });
            builder.HasData(new Role { ID = 3, RoleName = "Consultant", Order = ConstRolesOrder.Consultant, RoleDesc = "مشاور" });
            builder.HasData(new Role { ID = 4, RoleName = "User", Order = ConstRolesOrder.User, RoleDesc = "کاربران " });
            builder.HasData(new Role { ID = 5, RoleName = "Customer", Order = ConstRolesOrder.Customer, RoleDesc = "مشتری" });

            base.Configure(builder);
        }
    }
}
