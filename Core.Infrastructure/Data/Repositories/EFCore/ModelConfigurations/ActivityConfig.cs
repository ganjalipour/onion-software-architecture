using Consulting.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;
using static Consulting.Common.Constants.ConstActivities;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class ActivityConfiguration : BaseEntityTypeConfiguration<Activity>
    {
        public override void Configure(EntityTypeBuilder<Activity> builder) {
            builder.HasIndex(u => u.Code).IsUnique(true);
            builder.HasData(new Activity { Id = dashboard, ParentId=0, Order = dashboard, Code=101, Title = "پیشخوان", Name = "dashboard", IsActive = true, IsMenu = true, Path="/mp/dashboard",IconClass="dashboard", Description= "این صفحه جهت نمایش داشبورد اصلی می باشد." });
            builder.HasData(new Activity { Id = SecurityMenuRoot, ParentId = 0, Order = SecurityMenuRoot, Code = 102, Title = "امنیت", Name = "Security", IsActive = true, IsMenu = true, Path = "/mp/roleManagement", IconClass = "legal", Description = "امنیت" });
            builder.HasData(new Activity { Id = userManagement, ParentId= SecurityMenuRoot, Order = userManagement, Code=103, Title= "مدیریت کاربران", Name = "userManagement", IsActive=true, IsMenu=true, Path="/mp/userManagement", IconClass = "users", Description= "این صفحه جهت نمایش و مدیریت کاربران می باشد." });
            builder.HasData(new Activity { Id = branchesManagement, ParentId= SecurityMenuRoot, Code=104, Order = branchesManagement,  Title = "مدیریت دفاتر مشاوره", Name = "branchesManagement", IsActive= true, IsMenu=true, Path="/mp/branchesManagement", IconClass = "briefcase", Description = "این صفحه جهت نمایش و مدیریت دفاتر مشاوره می باشد." });
            builder.HasData(new Activity { Id = changePassword, ParentId= SecurityMenuRoot, Code=105, Title= "تغییر رمز", Order = changePassword, Name = "changePassword", IsActive= true, IsMenu=true, Path="/mp/changePassword", IconClass = "key", Description = "این صفحه جهت نمایش و مدیریت رمز می باشد." });
            builder.HasData(new Activity { Id = roleManagement, ParentId= SecurityMenuRoot, Code=106, Title = "مدیریت نقش ها", Order = roleManagement, Name = "roleManagement", IsActive = true, IsMenu = true, Path="/mp/roleManagement", IconClass = "keyboard-o", Description = "این صفحه جهت نمایش و مدیریت نقش ها می باشد." });

            builder.HasData(new Activity { Id = CustomerMenuRoot, ParentId = 0, Code = 107, Order = CustomerMenuRoot, Title = "مشتریان", Name = "Security", IsActive = true, IsMenu = true, Path = "/mp/roleManagement", IconClass = "legal", Description = "منوی مشتریان" });
            builder.HasData(new Activity { Id = CustomerManagement, ParentId = CustomerMenuRoot, Code = 109, Order = CustomerManagement, Title = "اطلاعات مشتریان / اعضا", Name = "Customer", IsActive = true, IsMenu = true, Path = "/mp/customerManagement", IconClass = "image", Description = "این صفحه جهت نمایش لیست مشتریان می باشد" });
            builder.HasData(new Activity { Id = WaitingPage, ParentId = 0, Code = 108, Order = WaitingPage, Title = "لطفا منتظر بمانید...", Name = "صفحه انتظار", IsActive = true, IsMenu = false, Path = "/mp/WaitingPage", IconClass=null, Description = "لطفا منتظر بمانید..." });

            builder.HasData(new Activity { Id = Sessions, ParentId = 0, Code = 110, Order = Sessions, Title = "جلسات", Name = "Sessions", IsActive = true, IsMenu = true, Path = "/mp/Sessions", IconClass = "legal", Description = "جلسات" });
            builder.HasData(new Activity { Id = MessagesManagement, ParentId = Sessions, Code = 111, Order = MessagesManagement, Title = "مدیریت پیام ها", Name = "MessagesManagement", IsActive = true, IsMenu = true, Path = "/mp/Messages", IconClass = "legal", Description = "مدیریت پیام ها" });
            builder.HasData(new Activity { Id = SessionsManagement, ParentId = Sessions, Code = 112, Order = SessionsManagement, Title = "مدیریت جلسات", Name = "SessionsManagement", IsActive = true, IsMenu = true, Path = "/mp/SessionManagement", IconClass = "legal", Description = "مدیریت جلسات" });

            builder.HasData(new Activity { Id = ExitMenu, ParentId = 0, Code = 113, Order = OrderExitMenu, Title = "خروج", Name = "SignOut", IsActive = true, IsMenu = true, Path = "/mp/logOut", IconClass = "sign-out-alt", Description = "خروج" });

            base.Configure(builder);
        }
    }
}
