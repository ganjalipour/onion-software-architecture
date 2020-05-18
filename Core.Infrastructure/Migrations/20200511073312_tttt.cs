using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class tttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmCode",
                schema: "Core",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "IconClass", "Name" },
                values: new object[] { "sign-out-alt", "SignOut" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmCode",
                schema: "Core",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "IconClass", "Name" },
                values: new object[] { "legal", "Sessions" });
        }
    }
}
