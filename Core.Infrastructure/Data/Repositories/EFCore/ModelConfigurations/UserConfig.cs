using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Consulting.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class UserConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                ID = 1,
                Password = "S1S22YRaY28iYuYV2rhDBkj5tZzEk0swJpWlA735pAY=",
                UserName = "Admin",
                FirstName = "محسن",
                LastName = "قاسم زاده",
                NationalCode = "2755731923",
                IsActive = true
                        ,
                IsRequireChangePass = true,
                PhoneNumber = "09149686690"
            }); builder.HasMany(x => x.ReceiverUserMessages).WithOne(b => b.ReceiverUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.SenderUserMessages).WithOne(b => b.SenderUser).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(u => u.UserName).IsUnique(true);
            base.Configure(builder);
        }
    }

    public class UserBranchRoleConfiguration : BaseEntityTypeConfiguration<UserBranchRole>
    {
        public override void Configure(EntityTypeBuilder<UserBranchRole> builder)
        {
            builder.HasData(new UserBranchRole() { ID = 1, BranchId = 1, UserId = 1, RoleId = 1 });
            builder.HasOne(d => d.Role).WithMany(p => p.UserBranchRoles);
            builder.HasOne(d => d.User).WithMany(p => p.UserBranchRoles);
            builder.HasIndex(p => new { p.UserId, p.RoleId, p.BranchId }).IsUnique(true);
            base.Configure(builder);
            builder.HasOne(p => p.Role).WithMany(p => p.UserBranchRoles).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class UserBranchConfiguration : BaseEntityTypeConfiguration<UserBranches>
    {
        public override void Configure(EntityTypeBuilder<UserBranches> builder)
        {
            builder.HasOne(p => p.Branch).WithMany(p => p.UserBranches).HasForeignKey(p => p.BranchId);
            builder.HasOne(d => d.Branch).WithMany(p => p.UserBranches);
            builder.HasOne(d => d.User).WithMany(p => p.UserBranches);
            builder.HasIndex(p => new { p.UserId, p.BranchId }).IsUnique(true);
            builder.HasData(new UserBranches() { ID = 1, BranchId = 1, UserId = 1 });
            base.Configure(builder);
        }
    }
}
