using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class _83746 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Consult");

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "Consult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    IssuerID = table.Column<string>(nullable: true),
                    IssueTime = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConsultType",
                schema: "Consult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultName = table.Column<string>(nullable: true),
                    ConsultDesc = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Expertise",
                schema: "Consult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertiseName = table.Column<string>(nullable: true),
                    ExpertiseDesc = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertise", x => x.ID);
                });

            migrationBuilder.InsertData(
                schema: "Consult",
                table: "ConsultType",
                columns: new[] { "ID", "ConsultDesc", "ConsultName", "ModifiedBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "شغلی", "Job", null, null },
                    { 2, "تحصیلی", "educational", null, null },
                    { 3, "خانواده", "Family", null, null },
                    { 4, "ازدواج", "Marriage", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Consult",
                table: "Expertise",
                columns: new[] { "ID", "ExpertiseDesc", "ExpertiseName", "ModifiedBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "پزشکان سلامت", "HealthDoctors", null, null },
                    { 2, "وکلای دادگستری", "Lawyers", null, null },
                    { 3, "روانشناس", "Psychologist", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment",
                schema: "Consult");

            migrationBuilder.DropTable(
                name: "ConsultType",
                schema: "Consult");

            migrationBuilder.DropTable(
                name: "Expertise",
                schema: "Consult");
        }
    }
}
