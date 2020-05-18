using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class plpop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AttachmentTypeCategoryID", "AttachmentTypeCode", "AttachmentTypeDesc", "IsRequierd" },
                values: new object[] { 2, 11130, " عکس کاربری", false });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AttachmentTypeCode", "AttachmentTypeDesc" },
                values: new object[] { 1112, "عکس شناسنامه" });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "AttachmentTypeCode", "AttachmentTypeDesc", "IsRequierd" },
                values: new object[] { 11121, "کارت ملی", true });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "AttachmentTypeCode", "AttachmentTypeDesc" },
                values: new object[] { 11122, "کارت پایان خدمت" });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "AttachmentTypeCode", "AttachmentTypeDesc" },
                values: new object[] { 11123, "مدرک تحصیلی" });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "AttachmentTypeCategoryID", "AttachmentTypeCode", "AttachmentTypeDesc" },
                values: new object[] { 1, 11128, "گذر نامه" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AttachmentTypeCategoryID", "AttachmentTypeCode", "AttachmentTypeDesc", "IsRequierd" },
                values: new object[] { 1, 1112, "عکس شناسنامه", true });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AttachmentTypeCode", "AttachmentTypeDesc" },
                values: new object[] { 11121, "کارت ملی" });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "AttachmentTypeCode", "AttachmentTypeDesc", "IsRequierd" },
                values: new object[] { 11122, "کارت پایان خدمت", false });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "AttachmentTypeCode", "AttachmentTypeDesc" },
                values: new object[] { 11123, "مدرک تحصیلی" });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "AttachmentTypeCode", "AttachmentTypeDesc" },
                values: new object[] { 11128, "گذر نامه" });

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "AttachmentTypes",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "AttachmentTypeCategoryID", "AttachmentTypeCode", "AttachmentTypeDesc" },
                values: new object[] { 2, 11130, " عکس کاربری" });
        }
    }
}
