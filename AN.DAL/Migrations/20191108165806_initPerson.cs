using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace AN.DAL.Migrations
{
    public partial class initPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "an");

            migrationBuilder.CreateTable(
                name: " PharmaceuticalGroup",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Name_Ku = table.Column<string>(maxLength: 255, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ PharmaceuticalGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlockedIp",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAddress = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedIp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(maxLength: 15, nullable: true),
                    Topic = table.Column<string>(maxLength: 100, nullable: false),
                    Message = table.Column<string>(maxLength: 1000, nullable: false),
                    IsArchived = table.Column<bool>(nullable: false, defaultValue: false),
                    IsUnread = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 255, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 255, nullable: false),
                    CommercialName = table.Column<string>(maxLength: 255, nullable: false),
                    EffectMechanism = table.Column<string>(maxLength: 1000, nullable: true),
                    EffectMechanism_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    EffectMechanism_Ar = table.Column<string>(maxLength: 1000, nullable: true),
                    ConsumptionTypes = table.Column<string>(maxLength: 1000, nullable: true),
                    ConsumptionTypes_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    ConsumptionTypes_Ar = table.Column<string>(maxLength: 1000, nullable: true),
                    SideEffects = table.Column<string>(maxLength: 1000, nullable: true),
                    SideEffects_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    SideEffects_Ar = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Controller = table.Column<string>(maxLength: 256, nullable: true),
                    Action = table.Column<string>(maxLength: 256, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    Parameters = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpertiseCategory",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertiseCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NamePrefix = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    ThirdName = table.Column<string>(maxLength: 50, nullable: false),
                    ThirdName_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    ThirdName_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<float>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Mobile = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Avatar = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    IsApproved = table.Column<bool>(nullable: false, defaultValue: true),
                    CreationPlaceId = table.Column<int>(nullable: true),
                    CreatorRole = table.Column<int>(nullable: true),
                    UniqueId = table.Column<string>(maxLength: 5, nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    Weight = table.Column<float>(nullable: true),
                    Height = table.Column<float>(nullable: true),
                    IdNumber = table.Column<string>(maxLength: 50, nullable: true),
                    LivingLocation = table.Column<string>(maxLength: 500, nullable: true),
                    MarriageStatus = table.Column<int>(nullable: true),
                    Language = table.Column<int>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    _FcmInstanceIds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Key = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: false),
                    Downloads = table.Column<int>(nullable: false),
                    Version = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificCategory",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 100, nullable: false),
                    CenterType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    UserOs = table.Column<string>(nullable: true),
                    Referer = table.Column<string>(nullable: true),
                    PageViewed = table.Column<string>(nullable: true),
                    DateStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VocationDay",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DayOfWeek = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocationDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugGroups",
                schema: "an",
                columns: table => new
                {
                    PharmaceuticalGroupId = table.Column<int>(nullable: false),
                    DrugId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugGroups", x => new { x.PharmaceuticalGroupId, x.DrugId });
                    table.UniqueConstraint("AK_DrugGroups_DrugId_PharmaceuticalGroupId", x => new { x.DrugId, x.PharmaceuticalGroupId });
                    table.ForeignKey(
                        name: "FK_DrugGroups_Drug_DrugId",
                        column: x => x.DrugId,
                        principalSchema: "an",
                        principalTable: "Drug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrugGroups_ PharmaceuticalGroup_PharmaceuticalGroupId",
                        column: x => x.PharmaceuticalGroupId,
                        principalSchema: "an",
                        principalTable: " PharmaceuticalGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expertise",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    ExpertiseCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expertise_ExpertiseCategory_ExpertiseCategoryId",
                        column: x => x.ExpertiseCategoryId,
                        principalSchema: "an",
                        principalTable: "ExpertiseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientPersonInfo",
                schema: "an",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeTurnsCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPersonInfo", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_PatientPersonInfo_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonUserProfile",
                schema: "an",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityUserId = table.Column<string>(nullable: false),
                    IdentityUserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonUserProfile", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_PersonUserProfile_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "an",
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    ServiceCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_ServiceCategory_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalSchema: "an",
                        principalTable: "ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientInsurances",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    InsuranceId = table.Column<int>(nullable: false),
                    UserPatientId = table.Column<int>(nullable: false),
                    InsuranceNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientInsurances_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "an",
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientInsurances_PatientPersonInfo_UserPatientId",
                        column: x => x.UserPatientId,
                        principalSchema: "an",
                        principalTable: "PatientPersonInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 1000, nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Address_Ku = table.Column<string>(maxLength: 255, nullable: true),
                    Address_Ar = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookMessage = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookMessage_Ku = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookMessage_Ar = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookSMSMessage = table.Column<string>(maxLength: 50, nullable: true),
                    FinalBookSMSMessage_Ku = table.Column<string>(maxLength: 50, nullable: true),
                    FinalBookSMSMessage_Ar = table.Column<string>(maxLength: 50, nullable: true),
                    IsGovernmental = table.Column<bool>(nullable: false, defaultValue: false),
                    Type = table.Column<int>(nullable: false),
                    Location = table.Column<Point>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false, defaultValue: false),
                    Notification = table.Column<string>(maxLength: 500, nullable: true),
                    Notification_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Notification_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    PhoneNumbers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospital_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "an",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Address_Ku = table.Column<string>(maxLength: 255, nullable: true),
                    Address_Ar = table.Column<string>(maxLength: 255, nullable: true),
                    Location = table.Column<Point>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 1000, nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Images = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacy_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "an",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 100, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 100, nullable: false),
                    IsIndependent = table.Column<bool>(nullable: false, defaultValue: true),
                    IsGovernmental = table.Column<bool>(nullable: false, defaultValue: false),
                    IsHostelry = table.Column<bool>(nullable: false, defaultValue: false),
                    Type = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Address_Ku = table.Column<string>(maxLength: 255, nullable: true),
                    Address_Ar = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    FinalBookMessage = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookMessage_Ku = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookMessage_Ar = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookSMSMessage = table.Column<string>(maxLength: 50, nullable: true),
                    FinalBookSMSMessage_Ku = table.Column<string>(maxLength: 50, nullable: true),
                    FinalBookSMSMessage_Ar = table.Column<string>(maxLength: 50, nullable: true),
                    HospitalId = table.Column<int>(nullable: true),
                    Location = table.Column<Point>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false, defaultValue: false),
                    Notification = table.Column<string>(maxLength: 500, nullable: true),
                    Notification_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Notification_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    PhoneNumbers = table.Column<string>(nullable: true),
                    Images = table.Column<string>(nullable: true),
                    Vocations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "an",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clinic_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "an",
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalPersons",
                schema: "an",
                columns: table => new
                {
                    HospitalId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsManager = table.Column<bool>(nullable: false, defaultValue: false),
                    TempGeneratedPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalPersons", x => new { x.HospitalId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_HospitalPersons_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "an",
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalPersons_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicPersons",
                schema: "an",
                columns: table => new
                {
                    Clinic_Id = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsManager = table.Column<bool>(nullable: false, defaultValue: false),
                    TempGeneratedPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicPersons", x => new { x.Clinic_Id, x.PersonId });
                    table.ForeignKey(
                        name: "FK_ClinicPersons_Clinic_Clinic_Id",
                        column: x => x.Clinic_Id,
                        principalSchema: "an",
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicPersons_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftCenter",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ku = table.Column<string>(maxLength: 50, nullable: false),
                    Name_Ar = table.Column<string>(maxLength: 50, nullable: false),
                    IsIndependent = table.Column<bool>(nullable: false, defaultValue: true),
                    CityId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Address_Ku = table.Column<string>(maxLength: 255, nullable: true),
                    Address_Ar = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 1000, nullable: true),
                    KnownAsDoctorName = table.Column<bool>(nullable: false, defaultValue: false),
                    BookingRestrictionHours = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ClinicId = table.Column<int>(nullable: true),
                    FinalBookMessage = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookMessage_Ku = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookMessage_Ar = table.Column<string>(maxLength: 255, nullable: true),
                    FinalBookSMSMessage = table.Column<string>(maxLength: 50, nullable: true),
                    FinalBookSMSMessage_Ku = table.Column<string>(maxLength: 50, nullable: true),
                    FinalBookSMSMessage_Ar = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<Point>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false, defaultValue: false),
                    Notification = table.Column<string>(maxLength: 500, nullable: true),
                    Notification_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Notification_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    AutomaticScheduleEnabled = table.Column<bool>(nullable: false),
                    ActiveDaysAhead = table.Column<int>(nullable: false),
                    FcmInstanceIds = table.Column<string>(nullable: true),
                    PhoneNumbers = table.Column<string>(nullable: true),
                    Images = table.Column<string>(nullable: true),
                    Vocations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftCenter_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "an",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftCenter_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "an",
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlockedMobiles",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mobile = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ShiftCenterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedMobiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockedMobiles_ShiftCenter_ShiftCenterId",
                        column: x => x.ShiftCenterId,
                        principalSchema: "an",
                        principalTable: "ShiftCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSupply",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    VisitPrice = table.Column<long>(nullable: false),
                    PrePaymentPercent = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    OnlineReservationPercent = table.Column<int>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    StartReservationDate = table.Column<DateTime>(nullable: false),
                    ReservationRangeStartPoint = table.Column<int>(nullable: false),
                    ReservationRangeEndPointPosition = table.Column<int>(nullable: false),
                    ReservationRangeEndPointDiffMinutes = table.Column<int>(nullable: false),
                    ShiftCenterId = table.Column<int>(nullable: false),
                    Notification = table.Column<string>(maxLength: 500, nullable: false),
                    Notification_Ku = table.Column<string>(maxLength: 500, nullable: false),
                    Notification_Ar = table.Column<string>(maxLength: 500, nullable: false),
                    ReservationType = table.Column<int>(nullable: false),
                    Vocations = table.Column<string>(nullable: true),
                    RankScore = table.Column<long>(nullable: false),
                    TotalRating = table.Column<double>(nullable: true),
                    TotalRaters = table.Column<int>(nullable: true),
                    AverageRating = table.Column<double>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSupply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSupply_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceSupply_ShiftCenter_ShiftCenterId",
                        column: x => x.ShiftCenterId,
                        principalSchema: "an",
                        principalTable: "ShiftCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftCenterPersons",
                schema: "an",
                columns: table => new
                {
                    ShiftCenterId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsManager = table.Column<bool>(nullable: false, defaultValue: false),
                    IsPatient = table.Column<bool>(nullable: false),
                    TempGeneratedPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftCenterPersons", x => new { x.ShiftCenterId, x.PersonId });
                    table.UniqueConstraint("AK_ShiftCenterPersons_PersonId_ShiftCenterId", x => new { x.PersonId, x.ShiftCenterId });
                    table.ForeignKey(
                        name: "FK_ShiftCenterPersons_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftCenterPersons_ShiftCenter_ShiftCenterId",
                        column: x => x.ShiftCenterId,
                        principalSchema: "an",
                        principalTable: "ShiftCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftCenterService",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ShiftCenterId = table.Column<int>(nullable: false),
                    HealthServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftCenterService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftCenterService_Service_HealthServiceId",
                        column: x => x.HealthServiceId,
                        principalSchema: "an",
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftCenterService_ShiftCenter_ShiftCenterId",
                        column: x => x.ShiftCenterId,
                        principalSchema: "an",
                        principalTable: "ShiftCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorActivityLog",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Action = table.Column<int>(nullable: false),
                    ServiceSupplyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorActivityLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorActivityLog_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSupplyInfo",
                schema: "an",
                columns: table => new
                {
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedicalCouncilNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Bio = table.Column<string>(maxLength: 100, nullable: true),
                    Bio_Ku = table.Column<string>(maxLength: 100, nullable: true),
                    Bio_Ar = table.Column<string>(maxLength: 100, nullable: true),
                    Picture = table.Column<string>(maxLength: 255, nullable: true),
                    Website = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Description_Ku = table.Column<string>(maxLength: 1000, nullable: false),
                    Description_Ar = table.Column<string>(maxLength: 1000, nullable: false),
                    WorkExperience = table.Column<float>(nullable: false, defaultValue: 0f),
                    AcceptionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSupplyInfo", x => x.ServiceSupplyId);
                    table.ForeignKey(
                        name: "FK_ServiceSupplyInfo_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    MaxCount = table.Column<int>(nullable: false),
                    RemainedCount = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    ShiftCenterServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_ShiftCenterService_ShiftCenterServiceId",
                        column: x => x.ShiftCenterServiceId,
                        principalSchema: "an",
                        principalTable: "ShiftCenterService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Start_DateTime = table.Column<DateTime>(nullable: false),
                    End_DateTime = table.Column<DateTime>(nullable: false),
                    DayOfWeek = table.Column<string>(maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    MaxCount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    ShiftCenterServiceId = table.Column<int>(nullable: false),
                    Prerequisite = table.Column<int>(nullable: false),
                    Shift = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_ShiftCenterService_ShiftCenterServiceId",
                        column: x => x.ShiftCenterServiceId,
                        principalSchema: "an",
                        principalTable: "ShiftCenterService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsualSchedulePlan",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DayOfWeek = table.Column<int>(nullable: false),
                    Shift = table.Column<int>(nullable: false),
                    StartTime = table.Column<string>(maxLength: 8, nullable: false),
                    EndTime = table.Column<string>(maxLength: 8, nullable: false),
                    Prerequisite = table.Column<int>(nullable: false),
                    MaxCount = table.Column<int>(nullable: false),
                    ValidFromDate = table.Column<DateTime>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    ShiftCenterServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsualSchedulePlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsualSchedulePlan_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsualSchedulePlan_ShiftCenterService_ShiftCenterServiceId",
                        column: x => x.ShiftCenterServiceId,
                        principalSchema: "an",
                        principalTable: "ShiftCenterService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalExpertise",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Name_Ku = table.Column<string>(maxLength: 50, nullable: true),
                    Name_Ar = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    UserDoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalExpertise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalExpertise_ServiceSupplyInfo_UserDoctorId",
                        column: x => x.UserDoctorId,
                        principalSchema: "an",
                        principalTable: "ServiceSupplyInfo",
                        principalColumn: "ServiceSupplyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorExpertise",
                schema: "an",
                columns: table => new
                {
                    UserDoctorId = table.Column<int>(nullable: false),
                    ExpertiseId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScientificCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorExpertise", x => new { x.UserDoctorId, x.ExpertiseId });
                    table.ForeignKey(
                        name: "FK_DoctorExpertise_Expertise_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalSchema: "an",
                        principalTable: "Expertise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorExpertise_ScientificCategory_ScientificCategoryId",
                        column: x => x.ScientificCategoryId,
                        principalSchema: "an",
                        principalTable: "ScientificCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorExpertise_ServiceSupplyInfo_UserDoctorId",
                        column: x => x.UserDoctorId,
                        principalSchema: "an",
                        principalTable: "ServiceSupplyInfo",
                        principalColumn: "ServiceSupplyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Book_DateTime = table.Column<DateTime>(nullable: false),
                    Start_DateTime = table.Column<DateTime>(nullable: false),
                    End_DateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Paymentstatus = table.Column<int>(nullable: false),
                    ReservationChannel = table.Column<int>(nullable: false),
                    IsAnnounced = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    PatientInsuranceId = table.Column<int>(nullable: true),
                    ShiftCenterServiceId = table.Column<int>(nullable: false),
                    OfferId = table.Column<int>(nullable: true),
                    UniqueTrackingCode = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Offer_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "an",
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_PatientInsurances_PatientInsuranceId",
                        column: x => x.PatientInsuranceId,
                        principalSchema: "an",
                        principalTable: "PatientInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_ShiftCenterService_ShiftCenterServiceId",
                        column: x => x.ShiftCenterServiceId,
                        principalSchema: "an",
                        principalTable: "ShiftCenterService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsualScheduleInsurances",
                schema: "an",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false),
                    InsuranceId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    AdmissionCapacity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsualScheduleInsurances", x => new { x.ScheduleId, x.InsuranceId });
                    table.UniqueConstraint("AK_UsualScheduleInsurances_InsuranceId_ScheduleId", x => new { x.InsuranceId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_UsualScheduleInsurances_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "an",
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsualScheduleInsurances_UsualSchedulePlan_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "an",
                        principalTable: "UsualSchedulePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfo",
                schema: "an",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    SaleReferenceId = table.Column<long>(nullable: false),
                    SaleOrderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfo", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_PaymentInfo_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "an",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSupplyRating",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSupplyRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSupplyRating_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "an",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceSupplyRating_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceSupplyRating_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftCenterMessage",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    MessageId = table.Column<long>(nullable: true),
                    MessageStatus = table.Column<long>(nullable: true),
                    SendingDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    About = table.Column<int>(nullable: false),
                    MessageBody = table.Column<string>(maxLength: 500, nullable: false),
                    Recipient = table.Column<string>(maxLength: 128, nullable: false),
                    SendingRetryCount = table.Column<int>(nullable: false),
                    GettingStatusCount = table.Column<int>(nullable: false),
                    ShiftCenterId = table.Column<int>(nullable: false),
                    SenderUserName = table.Column<string>(nullable: true),
                    ReceiverPersonId = table.Column<int>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftCenterMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftCenterMessage_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "an",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftCenterMessage_Person_ReceiverPersonId",
                        column: x => x.ReceiverPersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftCenterMessage_ShiftCenter_ShiftCenterId",
                        column: x => x.ShiftCenterId,
                        principalSchema: "an",
                        principalTable: "ShiftCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentHistory",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    Problems = table.Column<string>(maxLength: 1000, nullable: false),
                    Problems_Ku = table.Column<string>(maxLength: 1000, nullable: false),
                    Problems_Ar = table.Column<string>(maxLength: 1000, nullable: false),
                    Treatments = table.Column<string>(maxLength: 1000, nullable: false),
                    Treatments_Ku = table.Column<string>(maxLength: 1000, nullable: false),
                    Treatments_Ar = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Description_Ku = table.Column<string>(maxLength: 1000, nullable: false),
                    Description_Ar = table.Column<string>(maxLength: 1000, nullable: false),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentHistory_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "an",
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentHistory_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentHistory_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentAttachments",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ThumbnailUrl = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Size = table.Column<double>(nullable: false),
                    DeleteUrl = table.Column<string>(nullable: false),
                    FileType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    TreatmentHistoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentAttachments_TreatmentHistory_TreatmentHistoryId",
                        column: x => x.TreatmentHistoryId,
                        principalSchema: "an",
                        principalTable: "TreatmentHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentsItems",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomDrugName = table.Column<string>(maxLength: 500, nullable: true),
                    CustomDrugName_Ku = table.Column<string>(maxLength: 500, nullable: true),
                    CustomDrugName_Ar = table.Column<string>(maxLength: 500, nullable: true),
                    Dosage = table.Column<string>(maxLength: 5, nullable: true),
                    Frequency = table.Column<string>(maxLength: 150, nullable: true),
                    Quantity = table.Column<string>(maxLength: 50, nullable: true),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 1000, nullable: true),
                    DrugId = table.Column<int>(nullable: true),
                    TreatmentHistoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentsItems_Drug_DrugId",
                        column: x => x.DrugId,
                        principalSchema: "an",
                        principalTable: "Drug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentsItems_TreatmentHistory_TreatmentHistoryId",
                        column: x => x.TreatmentHistoryId,
                        principalSchema: "an",
                        principalTable: "TreatmentHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "ExpertiseCategory",
                columns: new[] { "Id", "CreatedAt", "Description", "Description_Ar", "Description_Ku", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(4825), null, null, "شارەزای منداڵان", false, "Kids", "الأطفال", "منداڵان", null },
                    { 2, new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(7176), null, null, "شارەزای دڵ", false, "Heart", "قلب", "دڵ", null }
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Province",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 11, 8, 19, 58, 3, 819, DateTimeKind.Local).AddTicks(734), false, "Erbil", "اربیل", "هەولێر", null },
                    { 2, new DateTime(2019, 11, 8, 19, 58, 3, 819, DateTimeKind.Local).AddTicks(1974), false, "Sulaymaniyah", "السلیمانیه", "سلێمانی", null },
                    { 3, new DateTime(2019, 11, 8, 19, 58, 3, 819, DateTimeKind.Local).AddTicks(1979), false, "Dahuk", "دهوك", "دهۆک", null }
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "ScientificCategory",
                columns: new[] { "Id", "CreatedAt", "Description", "Description_Ar", "Description_Ku", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(842), null, null, "", false, "General", "عام", "گشتی", null },
                    { 2, new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(3330), null, null, "", false, "Specialist", "اختصاصی", "شارەزا", null },
                    { 3, new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(3354), null, null, "", false, "Expertise", "ماجیستر", "ماستەر", null }
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "ServiceCategory",
                columns: new[] { "Id", "CenterType", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4773), false, "Health", "الصحة", "تەندروستی", null },
                    { 2, 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4815), false, "Face", "الوجه", "دەموچاو", null },
                    { 3, 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4819), false, "Makeup", "مكياج", "مكياج", null },
                    { 4, 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4823), false, "Body", "الجسم", "جەستە", null },
                    { 5, 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4826), false, "Hair", "الشعر", "پرچ", null },
                    { 6, 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4829), false, "Laser", "ليزر", "لەیز‌ەر", null },
                    { 7, 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4832), false, "Nail", "الأضافر", "نینۆک", null },
                    { 8, 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4836), false, "Filler & Botox", "فلر و بوتوكس", "فلر و بوتوكس", null }
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "City",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ProvinceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(571), false, "Erbil", "اربیل", "هەولێر", 1, null },
                    { 2, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(631), false, "Sulaymaniyah", "السلیمانیه", "سلێمانی", 2, null },
                    { 3, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(636), false, "Dahuk", "دهوك", "دهۆک", 3, null }
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Expertise",
                columns: new[] { "Id", "CreatedAt", "Description", "Description_Ar", "Description_Ku", "ExpertiseCategoryId", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 11, 8, 19, 58, 3, 824, DateTimeKind.Local).AddTicks(728), null, null, "شارەزای بوواری منداڵان", 1, false, "Kids Specialist", "خبرة الأطفال", "شارەزای بوواری منداڵان", null },
                    { 2, new DateTime(2019, 11, 8, 19, 58, 3, 824, DateTimeKind.Local).AddTicks(769), null, null, "شارەزای دڵ", 2, false, "Heart Specialist", "أخصائي القلب", "شارەزای دڵ", null }
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ServiceCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 22, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9445), false, "Mask", "ماسك", "Mask", 5, null },
                    { 23, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9448), false, "Hair falling treatment", "علاج تساقط الشعر", "Hair falling treatment", 5, null },
                    { 24, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9451), false, "Hair transplant", "زرع الشعر", "Hair transplant", 5, null },
                    { 25, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9454), false, "Hair extension", "إكستنشن الشعر", "Hair extension", 5, null },
                    { 26, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9457), false, "Dye", "صبغ", "Dye", 5, null },
                    { 27, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9459), false, "Hair Styling", "تسريحة شعر", "Hair Styling", 5, null },
                    { 28, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9463), false, "Hair root dye", "صبغ اطراف الشعر", "Hair root dye", 5, null },
                    { 29, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9466), false, "Cutting", "قص شعر", "Cutting", 5, null },
                    { 32, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9475), false, "اونبرة", "اونبرة", "اونبرة", 5, null },
                    { 31, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9472), false, "موهير", "موهير", "موهير", 5, null },
                    { 21, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9441), false, "Keratin", "كرياتين", "Keratin", 5, null },
                    { 33, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9498), false, "Full body", "كامل الجسم", "Full body", 6, null },
                    { 34, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9501), false, "Face", "الوجه", "Face", 6, null },
                    { 35, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9522), false, "Manicure", "منيكير", "Manicure", 7, null },
                    { 36, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9525), false, "Pedicure", "بديكير", "Pedicure", 7, null },
                    { 37, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9528), false, "Gel", "جلّ الأظافر", "Gel", 7, null },
                    { 38, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9531), false, "Acrylic", "آكريليك", "Acrylic", 7, null },
                    { 30, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9470), false, "سشوار", "سشوار", "سشوار", 5, null },
                    { 20, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9421), false, "Body contouring", "Body contouring", "Body contouring", 4, null },
                    { 18, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9393), false, "Simple makeup", "مكياج ناعم", "Simple makeup", 3, null },
                    { 39, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9588), false, "Face", "الوجه", "Face", 8, null },
                    { 1, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(8964), false, "Visit", "يزور", "ڤیزیت", 1, null },
                    { 2, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9304), false, "Hydrofacial", "الهايدرا فيشيل", "Hydrofacial", 2, null },
                    { 3, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9309), false, "Scarlet", "سكارليت", "Scarlet", 2, null },
                    { 4, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9312), false, "Hypho", "هايفو", "Hypho", 2, null },
                    { 5, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9315), false, "PRP", "بلازما - PRP", "PRP", 2, null },
                    { 6, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9318), false, "Mesotherapy", "بلازماميزو", "Mesotherapy", 2, null },
                    { 7, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9321), false, "Thread face lifting", "شد الوجه بالخيوط", "Thread face lifting", 2, null },
                    { 8, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9324), false, "Eyebrow lifting", "رفع الحاجب", "Eyebrow lifting", 2, null },
                    { 9, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9327), false, "Pigmentation treatment", "علاج التصبغات", "Pigmentation treatment", 2, null },
                    { 10, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9330), false, "Acne & acne scar management", "علاج ندبات حب الشباب", "Acne & acne scar management", 2, null },
                    { 11, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9333), false, "Nose reconstruction", "عملية تجميل الأنف", "Nose reconstruction", 2, null },
                    { 12, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9336), false, "Nevus removal", "إزالة الشامة", "Nevus removal", 2, null },
                    { 13, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9339), false, "Carbon laser", "ليزر كربوني", "Carbon laser", 2, null },
                    { 14, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9343), false, "Eyebrow tatoo", "تاتو الحواجب", "Eyebrow tatoo ", 2, null },
                    { 15, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9346), false, "face Adjustments", "تعديل الوجه", "face Adjustments", 2, null },
                    { 16, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9349), false, "Eyebrow Extention", "إكستنشن الرموش ", "Eyebrow Extention", 2, null },
                    { 17, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9390), false, "Full makeup", "مكياج سهرة/ ثقيل", "Full makeup", 3, null },
                    { 19, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9418), false, "Sculpture", "نحت الجسم", "Sculpture", 4, null },
                    { 40, new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9591), false, "Body", "الجسم", "Body", 8, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalExpertise_UserDoctorId",
                schema: "an",
                table: "AdditionalExpertise",
                column: "UserDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_OfferId",
                schema: "an",
                table: "Appointment",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientInsuranceId",
                schema: "an",
                table: "Appointment",
                column: "PatientInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PersonId",
                schema: "an",
                table: "Appointment",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceSupplyId",
                schema: "an",
                table: "Appointment",
                column: "ServiceSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ShiftCenterServiceId",
                schema: "an",
                table: "Appointment",
                column: "ShiftCenterServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UniqueTrackingCode",
                schema: "an",
                table: "Appointment",
                column: "UniqueTrackingCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlockedMobiles_ShiftCenterId",
                schema: "an",
                table: "BlockedMobiles",
                column: "ShiftCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceId",
                schema: "an",
                table: "City",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_CityId",
                schema: "an",
                table: "Clinic",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_HospitalId",
                schema: "an",
                table: "Clinic",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPersons_PersonId",
                schema: "an",
                table: "ClinicPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorActivityLog_ServiceSupplyId",
                schema: "an",
                table: "DoctorActivityLog",
                column: "ServiceSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorExpertise_ExpertiseId",
                schema: "an",
                table: "DoctorExpertise",
                column: "ExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorExpertise_ScientificCategoryId",
                schema: "an",
                table: "DoctorExpertise",
                column: "ScientificCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertise_ExpertiseCategoryId",
                schema: "an",
                table: "Expertise",
                column: "ExpertiseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_CityId",
                schema: "an",
                table: "Hospital",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalPersons_PersonId",
                schema: "an",
                table: "HospitalPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_Code",
                schema: "an",
                table: "Offer",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ServiceSupplyId",
                schema: "an",
                table: "Offer",
                column: "ServiceSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ShiftCenterServiceId",
                schema: "an",
                table: "Offer",
                column: "ShiftCenterServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInsurances_InsuranceId",
                schema: "an",
                table: "PatientInsurances",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInsurances_UserPatientId",
                schema: "an",
                table: "PatientInsurances",
                column: "UserPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Mobile",
                schema: "an",
                table: "Person",
                column: "Mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_UniqueId",
                schema: "an",
                table: "Person",
                column: "UniqueId",
                unique: true,
                filter: "[UniqueId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_CityId",
                schema: "an",
                table: "Pharmacy",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_Key",
                schema: "an",
                table: "Resource",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ServiceSupplyId",
                schema: "an",
                table: "Schedule",
                column: "ServiceSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ShiftCenterServiceId",
                schema: "an",
                table: "Schedule",
                column: "ShiftCenterServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceCategoryId",
                schema: "an",
                table: "Service",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSupply_PersonId",
                schema: "an",
                table: "ServiceSupply",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSupply_ShiftCenterId",
                schema: "an",
                table: "ServiceSupply",
                column: "ShiftCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSupplyRating_AppointmentId",
                schema: "an",
                table: "ServiceSupplyRating",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSupplyRating_PersonId",
                schema: "an",
                table: "ServiceSupplyRating",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSupplyRating_ServiceSupplyId",
                schema: "an",
                table: "ServiceSupplyRating",
                column: "ServiceSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCenter_CityId",
                schema: "an",
                table: "ShiftCenter",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCenter_ClinicId",
                schema: "an",
                table: "ShiftCenter",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCenterMessage_AppointmentId",
                schema: "an",
                table: "ShiftCenterMessage",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCenterMessage_ReceiverPersonId",
                schema: "an",
                table: "ShiftCenterMessage",
                column: "ReceiverPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCenterMessage_ShiftCenterId",
                schema: "an",
                table: "ShiftCenterMessage",
                column: "ShiftCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCenterService_HealthServiceId",
                schema: "an",
                table: "ShiftCenterService",
                column: "HealthServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftCenterService_ShiftCenterId",
                schema: "an",
                table: "ShiftCenterService",
                column: "ShiftCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentAttachments_TreatmentHistoryId",
                schema: "an",
                table: "TreatmentAttachments",
                column: "TreatmentHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistory_AppointmentId",
                schema: "an",
                table: "TreatmentHistory",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistory_PersonId",
                schema: "an",
                table: "TreatmentHistory",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistory_ServiceSupplyId",
                schema: "an",
                table: "TreatmentHistory",
                column: "ServiceSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentsItems_DrugId",
                schema: "an",
                table: "TreatmentsItems",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentsItems_TreatmentHistoryId",
                schema: "an",
                table: "TreatmentsItems",
                column: "TreatmentHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UsualSchedulePlan_ServiceSupplyId",
                schema: "an",
                table: "UsualSchedulePlan",
                column: "ServiceSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_UsualSchedulePlan_ShiftCenterServiceId",
                schema: "an",
                table: "UsualSchedulePlan",
                column: "ShiftCenterServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_VocationDay_Date",
                schema: "an",
                table: "VocationDay",
                column: "Date",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalExpertise",
                schema: "an");

            migrationBuilder.DropTable(
                name: "BlockedIp",
                schema: "an");

            migrationBuilder.DropTable(
                name: "BlockedMobiles",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ClinicPersons",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ContactUs",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "an");

            migrationBuilder.DropTable(
                name: "DoctorActivityLog",
                schema: "an");

            migrationBuilder.DropTable(
                name: "DoctorExpertise",
                schema: "an");

            migrationBuilder.DropTable(
                name: "DrugGroups",
                schema: "an");

            migrationBuilder.DropTable(
                name: "EventLog",
                schema: "an");

            migrationBuilder.DropTable(
                name: "HospitalPersons",
                schema: "an");

            migrationBuilder.DropTable(
                name: "PaymentInfo",
                schema: "an");

            migrationBuilder.DropTable(
                name: "PersonUserProfile",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Pharmacy",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Resource",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ServiceSupplyRating",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ShiftCenterMessage",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ShiftCenterPersons",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Statistics",
                schema: "an");

            migrationBuilder.DropTable(
                name: "TreatmentAttachments",
                schema: "an");

            migrationBuilder.DropTable(
                name: "TreatmentsItems",
                schema: "an");

            migrationBuilder.DropTable(
                name: "UsualScheduleInsurances",
                schema: "an");

            migrationBuilder.DropTable(
                name: "VocationDay",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Expertise",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ScientificCategory",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ServiceSupplyInfo",
                schema: "an");

            migrationBuilder.DropTable(
                name: " PharmaceuticalGroup",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Drug",
                schema: "an");

            migrationBuilder.DropTable(
                name: "TreatmentHistory",
                schema: "an");

            migrationBuilder.DropTable(
                name: "UsualSchedulePlan",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ExpertiseCategory",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Appointment",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Offer",
                schema: "an");

            migrationBuilder.DropTable(
                name: "PatientInsurances",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ServiceSupply",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ShiftCenterService",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Insurances",
                schema: "an");

            migrationBuilder.DropTable(
                name: "PatientPersonInfo",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Service",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ShiftCenter",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ServiceCategory",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Clinic",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Hospital",
                schema: "an");

            migrationBuilder.DropTable(
                name: "City",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Province",
                schema: "an");
        }
    }
}
