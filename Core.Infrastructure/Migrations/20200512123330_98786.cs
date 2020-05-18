using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class _98786 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultDesc",
                schema: "Consult",
                table: "ConsultType");

            migrationBuilder.DropColumn(
                name: "ConsultName",
                schema: "Consult",
                table: "ConsultType");

            migrationBuilder.AddColumn<string>(
                name: "ConsultTypeDesc",
                schema: "Consult",
                table: "ConsultType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsultTypeName",
                schema: "Consult",
                table: "ConsultType",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Consult",
                table: "ConsultType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ConsultTypeDesc", "ConsultTypeName" },
                values: new object[] { "شغلی", "Job" });

            migrationBuilder.UpdateData(
                schema: "Consult",
                table: "ConsultType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ConsultTypeDesc", "ConsultTypeName" },
                values: new object[] { "تحصیلی", "Educational" });

            migrationBuilder.UpdateData(
                schema: "Consult",
                table: "ConsultType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ConsultTypeDesc", "ConsultTypeName" },
                values: new object[] { "خانواده", "Family" });

            migrationBuilder.UpdateData(
                schema: "Consult",
                table: "ConsultType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ConsultTypeDesc", "ConsultTypeName" },
                values: new object[] { "ازدواج", "Marriage" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultTypeDesc",
                schema: "Consult",
                table: "ConsultType");

            migrationBuilder.DropColumn(
                name: "ConsultTypeName",
                schema: "Consult",
                table: "ConsultType");

            migrationBuilder.AddColumn<string>(
                name: "ConsultDesc",
                schema: "Consult",
                table: "ConsultType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsultName",
                schema: "Consult",
                table: "ConsultType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Consult",
                table: "ConsultType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ConsultDesc", "ConsultName" },
                values: new object[] { "شغلی", "Job" });

            migrationBuilder.UpdateData(
                schema: "Consult",
                table: "ConsultType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ConsultDesc", "ConsultName" },
                values: new object[] { "تحصیلی", "educational" });

            migrationBuilder.UpdateData(
                schema: "Consult",
                table: "ConsultType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ConsultDesc", "ConsultName" },
                values: new object[] { "خانواده", "Family" });

            migrationBuilder.UpdateData(
                schema: "Consult",
                table: "ConsultType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ConsultDesc", "ConsultName" },
                values: new object[] { "ازدواج", "Marriage" });
        }
    }
}
