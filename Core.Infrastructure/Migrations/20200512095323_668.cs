using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class _668 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueTime",
                schema: "Consult",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "ConsultantID",
                schema: "Consult",
                table: "Expertise",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                schema: "Consult",
                table: "Comment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Consultant",
                schema: "Consult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ConsultTypeID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consultant_ConsultType_ConsultTypeID",
                        column: x => x.ConsultTypeID,
                        principalSchema: "Consult",
                        principalTable: "ConsultType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultant_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Consult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueUserID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IssuerDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                schema: "Consult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueUserID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IssuerDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    QuestionID = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reply_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalSchema: "Consult",
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expertise_ConsultantID",
                schema: "Consult",
                table: "Expertise",
                column: "ConsultantID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultant_ConsultTypeID",
                schema: "Consult",
                table: "Consultant",
                column: "ConsultTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultant_UserID",
                schema: "Consult",
                table: "Consultant",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_QuestionID",
                schema: "Consult",
                table: "Reply",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_Consultant_ConsultantID",
                schema: "Consult",
                table: "Expertise",
                column: "ConsultantID",
                principalSchema: "Consult",
                principalTable: "Consultant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expertise_Consultant_ConsultantID",
                schema: "Consult",
                table: "Expertise");

            migrationBuilder.DropTable(
                name: "Consultant",
                schema: "Consult");

            migrationBuilder.DropTable(
                name: "Reply",
                schema: "Consult");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Consult");

            migrationBuilder.DropIndex(
                name: "IX_Expertise_ConsultantID",
                schema: "Consult",
                table: "Expertise");

            migrationBuilder.DropColumn(
                name: "ConsultantID",
                schema: "Consult",
                table: "Expertise");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                schema: "Consult",
                table: "Comment");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueTime",
                schema: "Consult",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
