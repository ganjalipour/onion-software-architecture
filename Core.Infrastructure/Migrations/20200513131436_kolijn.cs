using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class kolijn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypeCategories",
                keyColumn: "ID",
                keyValue: 1,
                column: "AttachmentTypeCategoryCode",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypeCategories",
                keyColumn: "ID",
                keyValue: 2,
                column: "AttachmentTypeCategoryCode",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypeCategories",
                keyColumn: "ID",
                keyValue: 1,
                column: "AttachmentTypeCategoryCode",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypeCategories",
                keyColumn: "ID",
                keyValue: 2,
                column: "AttachmentTypeCategoryCode",
                value: 3);
        }
    }
}
