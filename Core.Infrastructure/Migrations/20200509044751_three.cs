using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Activities",
                columns: new[] { "Id", "Code", "Description", "IconClass", "IsActive", "IsMenu", "ModifiedBy", "Name", "Order", "ParentId", "Path", "Title", "UpdateDate" },
                values: new object[] { 13, 113, "خروج", "legal", true, true, null, "Sessions", 2000, 0, "/mp/logOut", "خروج", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Core",
                table: "RoleActivities",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Activities",
                columns: new[] { "Id", "Code", "Description", "IconClass", "IsActive", "IsMenu", "ModifiedBy", "Name", "Order", "ParentId", "Path", "Title", "UpdateDate" },
                values: new object[] { 2000, 113, "خروج", "legal", true, true, null, "Sessions", 2000, 0, "/mp/logOut", "خروج", null });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "RoleActivities",
                columns: new[] { "ID", "ActivityID", "ModifiedBy", "RoleID", "UpdateDate" },
                values: new object[] { 13, 13, null, 1, null });
        }
    }
}
