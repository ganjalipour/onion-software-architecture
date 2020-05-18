using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consulting.Infrastructure.Core.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.EnsureSchema(
                name: "Empowerment");

            migrationBuilder.CreateSequence<int>(
                name: "CustomerHeadSerialSequence",
                schema: "Customer");

            migrationBuilder.CreateSequence<int>(
                name: "TransactionSerialSequence",
                schema: "Customer");

            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Path = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IconClass = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsMenu = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentTypeCategories",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentTypeCategoryName = table.Column<string>(maxLength: 50, nullable: true),
                    AttachmentTypeCategoryCode = table.Column<int>(nullable: false),
                    AttachmentTypeCategoryID = table.Column<int>(nullable: false),
                    AttachmentTypeCategoryDesc = table.Column<string>(maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentTypeCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 50, nullable: true),
                    IsSeen = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryServiceStatus",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilitaryServiceStatusName = table.Column<string>(maxLength: 50, nullable: true),
                    MilitaryServiceStatusCode = table.Column<string>(maxLength: 25, nullable: true),
                    MilitaryServiceStatusDesc = table.Column<string>(maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryServiceStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityName = table.Column<string>(maxLength: 50, nullable: true),
                    NationalityCode = table.Column<string>(maxLength: 20, nullable: true),
                    NationalityDesc = table.Column<string>(maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false),
                    RoleDesc = table.Column<string>(maxLength: 250, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillTitle = table.Column<string>(maxLength: 100, nullable: true),
                    SkillCode = table.Column<string>(maxLength: 100, nullable: true),
                    SkillDesc = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    NationalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Password = table.Column<string>(maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsRequireChangePass = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(maxLength: 50, nullable: true),
                    ZoneDesc = table.Column<string>(maxLength: 250, nullable: true),
                    OSTAN = table.Column<string>(maxLength: 20, nullable: true),
                    OSTANCode = table.Column<string>(maxLength: 25, nullable: true),
                    OstanName = table.Column<string>(maxLength: 50, nullable: true),
                    SHAHRESTAN = table.Column<string>(maxLength: 20, nullable: true),
                    ShahrestName = table.Column<string>(maxLength: 50, nullable: true),
                    BAKHSH = table.Column<string>(maxLength: 20, nullable: true),
                    BakhshName = table.Column<string>(maxLength: 50, nullable: true),
                    Dehestan = table.Column<string>(maxLength: 20, nullable: true),
                    DehestanName = table.Column<string>(maxLength: 50, nullable: true),
                    Abadi = table.Column<string>(maxLength: 20, nullable: true),
                    AbadiName = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetailTypes",
                schema: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetailTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                schema: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationLevelsName = table.Column<string>(maxLength: 100, nullable: true),
                    EducationLevelsCode = table.Column<int>(nullable: false),
                    EducationLevelsDesc = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "Empowerment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchID = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentTypes",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentTypeName = table.Column<string>(maxLength: 50, nullable: true),
                    AttachmentTypeCode = table.Column<int>(nullable: false),
                    AttachmentTypeCategoryID = table.Column<int>(nullable: false),
                    IsRequierd = table.Column<bool>(nullable: false),
                    AttachmentTypeDesc = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttachmentTypes_AttachmentTypeCategories_AttachmentTypeCategoryID",
                        column: x => x.AttachmentTypeCategoryID,
                        principalSchema: "Core",
                        principalTable: "AttachmentTypeCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleActivities",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActivities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleActivities_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalSchema: "Core",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleActivities_Roles_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "Core",
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMessages",
                schema: "Core",
                columns: table => new
                {
                    UserMessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserID = table.Column<int>(nullable: true),
                    ReceiverUserID = table.Column<int>(nullable: true),
                    MessageID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessages", x => x.UserMessageID);
                    table.ForeignKey(
                        name: "FK_UserMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalSchema: "Core",
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMessages_Users_ReceiverUserID",
                        column: x => x.ReceiverUserID,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMessages_Users_SenderUserID",
                        column: x => x.SenderUserID,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneID = table.Column<int>(nullable: false),
                    BranchCode = table.Column<string>(maxLength: 25, nullable: true),
                    OSTANCode = table.Column<string>(maxLength: 25, nullable: true),
                    Serial = table.Column<int>(nullable: false),
                    BranchName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    MeetingAddress1 = table.Column<string>(maxLength: 500, nullable: true),
                    MeetingAddress2 = table.Column<string>(maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: true),
                    Fax = table.Column<string>(maxLength: 25, nullable: true),
                    BranchHeadName = table.Column<string>(maxLength: 50, nullable: true),
                    Latitude = table.Column<string>(maxLength: 25, nullable: true),
                    Longitude = table.Column<string>(maxLength: 25, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    BDN = table.Column<string>(maxLength: 25, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_Zones_ZoneID",
                        column: x => x.ZoneID,
                        principalSchema: "Core",
                        principalTable: "Zones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerHeads",
                schema: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    FatherName = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerUserID = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    BranchCode = table.Column<string>(maxLength: 100, nullable: true),
                    SSH = table.Column<string>(maxLength: 10, nullable: true),
                    NationalCode = table.Column<string>(maxLength: 10, nullable: true),
                    AccountStatusID = table.Column<int>(nullable: false),
                    SeriChar = table.Column<string>(nullable: true),
                    SeriNo = table.Column<int>(nullable: false),
                    Serial = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR Customer.CustomerHeadSerialSequence"),
                    IsMale = table.Column<bool>(nullable: false),
                    IsMaried = table.Column<bool>(nullable: false),
                    CustomerGroupID = table.Column<int>(nullable: false),
                    MilitaryServiceStatusID = table.Column<int>(nullable: false),
                    NationalityID = table.Column<int>(nullable: false),
                    LastEducationLevelID = table.Column<int>(nullable: false),
                    job = table.Column<string>(maxLength: 100, nullable: true),
                    Dependants = table.Column<int>(nullable: false),
                    IsCompany = table.Column<bool>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    EconomicCode = table.Column<int>(nullable: false),
                    RegisterationCode = table.Column<int>(nullable: false),
                    EducationLevelID = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerHeads", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerHeads_EducationLevels_EducationLevelID",
                        column: x => x.EducationLevelID,
                        principalSchema: "Customer",
                        principalTable: "EducationLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Approvals",
                schema: "Empowerment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    sessionID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Approvals_Sessions_sessionID",
                        column: x => x.sessionID,
                        principalSchema: "Empowerment",
                        principalTable: "Sessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionUsers",
                schema: "Empowerment",
                columns: table => new
                {
                    SessionUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    IsSignatory = table.Column<bool>(nullable: false),
                    SessonId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionUsers", x => x.SessionUserID);
                    table.ForeignKey(
                        name: "FK_SessionUsers_Sessions_SessonId",
                        column: x => x.SessonId,
                        principalSchema: "Empowerment",
                        principalTable: "Sessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionUsers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBranches",
                schema: "Core",
                columns: table => new
                {
                    UserBranchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranches", x => x.UserBranchID);
                    table.ForeignKey(
                        name: "FK_UserBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Core",
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBranches_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBranchRoles",
                schema: "Core",
                columns: table => new
                {
                    UserBranchRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranchRoles", x => x.UserBranchRoleID);
                    table.ForeignKey(
                        name: "FK_UserBranchRoles_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Core",
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranchRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Core",
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBranchRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "Core",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(maxLength: 100, nullable: true),
                    Desc = table.Column<string>(maxLength: 100, nullable: true),
                    Path = table.Column<string>(maxLength: 100, nullable: true),
                    FileType = table.Column<string>(maxLength: 100, nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    CustomerHeadID = table.Column<int>(nullable: true),
                    SessionID = table.Column<int>(nullable: true),
                    AttachmentTypeID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attachments_AttachmentTypes_AttachmentTypeID",
                        column: x => x.AttachmentTypeID,
                        principalSchema: "Core",
                        principalTable: "AttachmentTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_CustomerHeads_CustomerHeadID",
                        column: x => x.CustomerHeadID,
                        principalSchema: "Customer",
                        principalTable: "CustomerHeads",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalSchema: "Empowerment",
                        principalTable: "Sessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                schema: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerHeadID = table.Column<int>(nullable: false),
                    CustomerDetailTypeID = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_CustomerDetailTypes_CustomerDetailTypeID",
                        column: x => x.CustomerDetailTypeID,
                        principalSchema: "Customer",
                        principalTable: "CustomerDetailTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_CustomerHeads_CustomerHeadID",
                        column: x => x.CustomerHeadID,
                        principalSchema: "Customer",
                        principalTable: "CustomerHeads",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSkills",
                schema: "Customer",
                columns: table => new
                {
                    CustomerSkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    SkillID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "SYSDATETIME()"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValue: 1),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSkills", x => x.CustomerSkillID);
                    table.ForeignKey(
                        name: "FK_CustomerSkills_CustomerHeads_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "Customer",
                        principalTable: "CustomerHeads",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalSchema: "Core",
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Activities",
                columns: new[] { "Id", "Code", "Description", "IconClass", "IsActive", "IsMenu", "ModifiedBy", "Name", "Order", "ParentId", "Path", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 4, 104, "این صفحه جهت نمایش و مدیریت دفاتر مشاوره می باشد.", "briefcase", true, true, null, "branchesManagement", 0, 2, "/mp/branchesManagement", "مدیریت دفاتر مشاوره", null },
                    { 12, 112, "مدیریت جلسات", "legal", true, true, null, "SessionsManagement", 0, 10, "/mp/SessionManagement", "مدیریت جلسات", null },
                    { 11, 111, "مدیریت پیام ها", "legal", true, true, null, "MessagesManagement", 0, 10, "/mp/Messages", "مدیریت پیام ها", null },
                    { 10, 110, "جلسات", "legal", true, true, null, "Sessions", 0, 0, "/mp/Sessions", "جلسات", null },
                    { 9, 108, "لطفا منتظر بمانید...", null, true, false, null, "صفحه انتظار", 0, 0, "/mp/WaitingPage", "لطفا منتظر بمانید...", null },
                    { 8, 109, "این صفحه جهت نمایش لیست مشتریان می باشد", "image", true, true, null, "Customer", 0, 7, "/mp/customerManagement", "اطلاعات مشتریان / اعضا", null },
                    { 7, 107, "منوی مشتریان", "legal", true, true, null, "Security", 0, 0, "/mp/roleManagement", "مشتریان", null },
                    { 1, 101, "این صفحه جهت نمایش داشبورد اصلی می باشد.", "dashboard", true, true, null, "dashboard", 0, 0, "/mp/dashboard", "پیشخوان", null },
                    { 2, 102, "امنیت", "legal", true, true, null, "Security", 0, 0, "/mp/roleManagement", "امنیت", null },
                    { 3, 103, "این صفحه جهت نمایش و مدیریت کاربران می باشد.", "users", true, true, null, "userManagement", 0, 2, "/mp/userManagement", "مدیریت کاربران", null },
                    { 6, 106, "این صفحه جهت نمایش و مدیریت نقش ها می باشد.", "keyboard-o", true, true, null, "roleManagement", 0, 2, "/mp/roleManagement", "مدیریت نقش ها", null },
                    { 5, 105, "این صفحه جهت نمایش و مدیریت رمز می باشد.", "key", true, true, null, "changePassword", 0, 2, "/mp/changePassword", "تغییر رمز", null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "AttachmentTypeCategories",
                columns: new[] { "ID", "AttachmentTypeCategoryCode", "AttachmentTypeCategoryDesc", "AttachmentTypeCategoryID", "AttachmentTypeCategoryName", "ModifiedBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 2, "مشتریان", 0, null, null, null },
                    { 2, 3, "کاربران", 0, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "MilitaryServiceStatus",
                columns: new[] { "ID", "MilitaryServiceStatusCode", "MilitaryServiceStatusDesc", "MilitaryServiceStatusName", "ModifiedBy", "UpdateDate" },
                values: new object[,]
                {
                    { 3, null, "درحال خدمت", "Serving", null, null },
                    { 2, null, "معاف پزشکی", "Exempt", null, null },
                    { 1, null, "معاف", "Exempt", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Nationality",
                columns: new[] { "ID", "ModifiedBy", "NationalityCode", "NationalityDesc", "NationalityName", "UpdateDate" },
                values: new object[,]
                {
                    { 2, null, null, "خارجی", "Khareji", null },
                    { 1, null, null, "ایرانی", "Irani", null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Roles",
                columns: new[] { "ID", "ModifiedBy", "Order", "RoleDesc", "RoleName", "UpdateDate" },
                values: new object[,]
                {
                    { 5, null, 5, "مشتری", "Customer", null },
                    { 4, null, 4, "کاربران ", "User", null },
                    { 3, null, 3, "مشاور", "Consultant", null },
                    { 2, null, 2, "رئیس دفتر", "Supervisor", null },
                    { 1, null, 1, "مدیرارشد", "Administrator", null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Skills",
                columns: new[] { "ID", "ModifiedBy", "SkillCode", "SkillDesc", "SkillTitle", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, "نجاری", null, null },
                    { 2, null, null, "آشپزی", null, null },
                    { 3, null, null, "خیاطی", null, null },
                    { 4, null, null, "برنامه نویس", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Users",
                columns: new[] { "ID", "FirstName", "IsActive", "IsRequireChangePass", "LastName", "ModifiedBy", "NationalCode", "Password", "PhoneNumber", "UpdateDate", "UserName" },
                values: new object[] { 1, "محسن", true, true, "قاسم زاده", null, "2755731923", "S1S22YRaY28iYuYV2rhDBkj5tZzEk0swJpWlA735pAY=", "09149686690", null, "Admin" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Zones",
                columns: new[] { "ID", "Abadi", "AbadiName", "BAKHSH", "BakhshName", "Dehestan", "DehestanName", "ModifiedBy", "OSTAN", "OSTANCode", "OstanName", "SHAHRESTAN", "ShahrestName", "UpdateDate", "ZoneDesc", "ZoneName" },
                values: new object[] { 5, "00026", "امان آباد", "02", "مرکزی", "01", "امان آباد", null, "00", "38", "مرکزی", "01", "اراک", null, null, null });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "CustomerDetailTypes",
                columns: new[] { "ID", "Code", "ModifiedBy", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 6, "عکس امضا", null, "SignatureImage", null },
                    { 5, "عکس پرسنلی", null, "PersonalImage", null },
                    { 4, "عکس شناسنامه", null, "CertificateImage", null },
                    { 3, "آدرس", null, "Address", null },
                    { 2, "تلفن", null, "phone", null },
                    { 1, "موبایل", null, "Mobile", null }
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "EducationLevels",
                columns: new[] { "ID", "EducationLevelsCode", "EducationLevelsDesc", "EducationLevelsName", "ModifiedBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 0, "کارشناسی", "Bsc", null, null },
                    { 2, 0, "کارشناسی ارشد", "Masters", null, null },
                    { 3, 0, "دکترا و بالاتر", "Doctoral", null, null },
                    { 4, 0, "دیپلم", "diploma", null, null },
                    { 5, 0, "زیر دیپلم", "underdiploma", null, null },
                    { 6, 0, "فوق دیپلم", "upperdiploma", null, null },
                    { 7, 0, " بی سواد", "nonEducation", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "AttachmentTypes",
                columns: new[] { "ID", "AttachmentTypeCategoryID", "AttachmentTypeCode", "AttachmentTypeDesc", "AttachmentTypeName", "IsRequierd", "ModifiedBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, 1111, "عکس پرسنلی", null, false, null, null },
                    { 2, 1, 1112, "عکس شناسنامه", null, true, null, null },
                    { 3, 1, 11121, "کارت ملی", null, true, null, null },
                    { 4, 1, 11122, "کارت پایان خدمت", null, false, null, null },
                    { 5, 1, 11123, "مدرک تحصیلی", null, false, null, null },
                    { 6, 1, 11128, "گذر نامه", null, false, null, null },
                    { 7, 2, 11130, " امضا کاربری", null, false, null, null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Branches",
                columns: new[] { "ID", "Address", "BDN", "BranchCode", "BranchHeadName", "BranchName", "CustomerID", "Fax", "IsActive", "Latitude", "Longitude", "MeetingAddress1", "MeetingAddress2", "ModifiedBy", "OSTANCode", "PhoneNumber", "Serial", "UpdateDate", "ZoneID" },
                values: new object[] { 1, null, null, "380001", null, "تست", 0, null, true, null, null, null, null, null, "38", "09149686690", 1, null, 5 });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "RoleActivities",
                columns: new[] { "ID", "ActivityID", "ModifiedBy", "RoleID", "UpdateDate" },
                values: new object[,]
                {
                    { 2, 2, null, 1, null },
                    { 12, 12, null, 1, null },
                    { 4, 4, null, 1, null },
                    { 5, 5, null, 1, null },
                    { 6, 6, null, 1, null },
                    { 7, 7, null, 1, null },
                    { 8, 8, null, 1, null },
                    { 9, 9, null, 1, null },
                    { 10, 10, null, 1, null },
                    { 11, 11, null, 1, null },
                    { 1, 1, null, 1, null },
                    { 3, 3, null, 1, null }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "UserBranchRoles",
                columns: new[] { "UserBranchRoleID", "BranchId", "ModifiedBy", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { 1, 1, null, 1, null, 1 });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "UserBranches",
                columns: new[] { "UserBranchID", "BranchId", "ModifiedBy", "UpdateDate", "UserId" },
                values: new object[] { 1, 1, null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Code",
                schema: "Core",
                table: "Activities",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AttachmentTypeID",
                schema: "Core",
                table: "Attachments",
                column: "AttachmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CustomerHeadID",
                schema: "Core",
                table: "Attachments",
                column: "CustomerHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_SessionID",
                schema: "Core",
                table: "Attachments",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTypes_AttachmentTypeCategoryID",
                schema: "Core",
                table: "AttachmentTypes",
                column: "AttachmentTypeCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ZoneID",
                schema: "Core",
                table: "Branches",
                column: "ZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActivities_ID",
                schema: "Core",
                table: "RoleActivities",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleActivities_RoleID",
                schema: "Core",
                table: "RoleActivities",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActivities_ActivityID_RoleID",
                schema: "Core",
                table: "RoleActivities",
                columns: new[] { "ActivityID", "RoleID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                schema: "Core",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_BranchId",
                schema: "Core",
                table: "UserBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_UserId_BranchId",
                schema: "Core",
                table: "UserBranches",
                columns: new[] { "UserId", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchRoles_BranchId",
                schema: "Core",
                table: "UserBranchRoles",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchRoles_RoleId",
                schema: "Core",
                table: "UserBranchRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchRoles_UserId_RoleId_BranchId",
                schema: "Core",
                table: "UserBranchRoles",
                columns: new[] { "UserId", "RoleId", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_MessageID",
                schema: "Core",
                table: "UserMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_ReceiverUserID",
                schema: "Core",
                table: "UserMessages",
                column: "ReceiverUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_SenderUserID",
                schema: "Core",
                table: "UserMessages",
                column: "SenderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "Core",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_CustomerDetailTypeID",
                schema: "Customer",
                table: "CustomerDetails",
                column: "CustomerDetailTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_CustomerHeadID",
                schema: "Customer",
                table: "CustomerDetails",
                column: "CustomerHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHeads_EducationLevelID",
                schema: "Customer",
                table: "CustomerHeads",
                column: "EducationLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHeads_NationalCode",
                schema: "Customer",
                table: "CustomerHeads",
                column: "NationalCode",
                unique: true,
                filter: "[NationalCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSkills_CustomerID",
                schema: "Customer",
                table: "CustomerSkills",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSkills_SkillID",
                schema: "Customer",
                table: "CustomerSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_sessionID",
                schema: "Empowerment",
                table: "Approvals",
                column: "sessionID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionUsers_SessonId",
                schema: "Empowerment",
                table: "SessionUsers",
                column: "SessonId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionUsers_UserId",
                schema: "Empowerment",
                table: "SessionUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "MilitaryServiceStatus",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Nationality",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "RoleActivities",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "UserBranches",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "UserBranchRoles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "UserMessages",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "CustomerDetails",
                schema: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerSkills",
                schema: "Customer");

            migrationBuilder.DropTable(
                name: "Approvals",
                schema: "Empowerment");

            migrationBuilder.DropTable(
                name: "SessionUsers",
                schema: "Empowerment");

            migrationBuilder.DropTable(
                name: "AttachmentTypes",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "CustomerDetailTypes",
                schema: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerHeads",
                schema: "Customer");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Empowerment");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "AttachmentTypeCategories",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Zones",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "EducationLevels",
                schema: "Customer");

            migrationBuilder.DropSequence(
                name: "CustomerHeadSerialSequence",
                schema: "Customer");

            migrationBuilder.DropSequence(
                name: "TransactionSerialSequence",
                schema: "Customer");
        }
    }
}
