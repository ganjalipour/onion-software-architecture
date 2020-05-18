using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 12);

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Activities",
                columns: new[] { "Id", "Code", "Description", "IconClass", "IsActive", "IsMenu", "ModifiedBy", "Name", "Order", "ParentId", "Path", "Title", "UpdateDate" },
                values: new object[] { 2000, 113, "خروج", "legal", true, true, null, "Sessions", 2000, 0, "/mp/logOut", "خروج", null });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "RoleActivities",
                columns: new[] { "ID", "ActivityID", "ModifiedBy", "RoleID", "UpdateDate" },
                values: new object[] { 13, 2000, null, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.DeleteData(
                schema: "Core",
                table: "RoleActivities",
                keyColumn: "ID",
                keyValue: 2000);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 0);
        }
    }
}
