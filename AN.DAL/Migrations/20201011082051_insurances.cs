using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace AN.DAL.Migrations
{
    public partial class insurances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PatientInsurances_PatientInsuranceId",
                schema: "an",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientInsurances_Insurances_InsuranceId",
                schema: "an",
                table: "PatientInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientInsurances_PatientPersonInfo_UserPatientId",
                schema: "an",
                table: "PatientInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_UsualScheduleInsurances_Insurances_InsuranceId",
                schema: "an",
                table: "UsualScheduleInsurances");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UsualScheduleInsurances_InsuranceId_ScheduleId",
                schema: "an",
                table: "UsualScheduleInsurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientInsurances",
                schema: "an",
                table: "PatientInsurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurances",
                schema: "an",
                table: "Insurances");

            migrationBuilder.RenameTable(
                name: "PatientInsurances",
                schema: "an",
                newName: "PatientInsurance",
                newSchema: "an");

            migrationBuilder.RenameTable(
                name: "Insurances",
                schema: "an",
                newName: "Insurance",
                newSchema: "an");

            migrationBuilder.RenameColumn(
                name: "InsuranceId",
                schema: "an",
                table: "UsualScheduleInsurances",
                newName: "ServiceSupplyInsuranceId");

            migrationBuilder.RenameColumn(
                name: "InsuranceId",
                schema: "an",
                table: "PatientInsurance",
                newName: "ServiceSupplyInsuranceId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientInsurances_UserPatientId",
                schema: "an",
                table: "PatientInsurance",
                newName: "IX_PatientInsurance_UserPatientId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientInsurances_InsuranceId",
                schema: "an",
                table: "PatientInsurance",
                newName: "IX_PatientInsurance_ServiceSupplyInsuranceId");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyType",
                schema: "an",
                table: "ShiftCenterService",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                schema: "an",
                table: "ShiftCenterService",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note_Ar",
                schema: "an",
                table: "ShiftCenterService",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note_Ku",
                schema: "an",
                table: "ShiftCenterService",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "an",
                table: "ShiftCenterService",
                type: "decimal(19,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceWithDiscount",
                schema: "an",
                table: "ShiftCenterService",
                type: "decimal(19,4)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscountPercentange",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo_Ar",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo_Ku",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary_Ar",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary_Ku",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_Ar",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_Ku",
                schema: "an",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VisitsCount",
                schema: "an",
                table: "Offer",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                schema: "an",
                table: "Hospital",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                schema: "an",
                table: "Clinic",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_Ku",
                schema: "an",
                table: "Insurance",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name_Ar",
                schema: "an",
                table: "Insurance",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "an",
                table: "Insurance",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Ku",
                schema: "an",
                table: "Insurance",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Ar",
                schema: "an",
                table: "Insurance",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "an",
                table: "Insurance",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                schema: "an",
                table: "Insurance",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientInsurance",
                schema: "an",
                table: "PatientInsurance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurance",
                schema: "an",
                table: "Insurance",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DiseaseRecordsForm",
                schema: "an",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<long>(nullable: false, defaultValue: 0L),
                    HasLongTermDisease = table.Column<bool>(nullable: false, defaultValue: false),
                    LongTermDiseasesDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    DrugsYouUsed = table.Column<string>(maxLength: 1000, nullable: true),
                    MedicalAllergies = table.Column<string>(maxLength: 1000, nullable: true),
                    DoYouSmoke = table.Column<bool>(nullable: false, defaultValue: false),
                    HadSurgery = table.Column<bool>(nullable: false, defaultValue: false),
                    SurgeriesDescription = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseRecordsForm", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_DiseaseRecordsForm_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceBranch",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    Address_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    Address_Ar = table.Column<string>(maxLength: 1000, nullable: true),
                    Location = table.Column<Point>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    InsuranceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceBranch_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "an",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceBranch_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "an",
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceService",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    Title_Ku = table.Column<string>(maxLength: 256, nullable: true),
                    Title_Ar = table.Column<string>(maxLength: 256, nullable: true),
                    Summary = table.Column<string>(maxLength: 512, nullable: true),
                    Summary_Ku = table.Column<string>(maxLength: 512, nullable: true),
                    Summary_Ar = table.Column<string>(maxLength: 512, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ku = table.Column<string>(maxLength: 1000, nullable: true),
                    Description_Ar = table.Column<string>(maxLength: 1000, nullable: true),
                    HasAttachments = table.Column<bool>(nullable: false),
                    InsuranceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceService_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "an",
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSupplyInsurance",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    InsuranceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSupplyInsurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSupplyInsurance_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalSchema: "an",
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceSupplyInsurance_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleInsurance",
                schema: "an",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false),
                    ServiceSupplyInsuranceId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    AdmissionCapacity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleInsurance", x => new { x.ScheduleId, x.ServiceSupplyInsuranceId });
                    table.ForeignKey(
                        name: "FK_ScheduleInsurance_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "an",
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleInsurance_ServiceSupplyInsurance_ServiceSupplyInsuranceId",
                        column: x => x.ServiceSupplyInsuranceId,
                        principalSchema: "an",
                        principalTable: "ServiceSupplyInsurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 159, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 159, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 159, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 161, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 161, DateTimeKind.Local).AddTicks(6928));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 161, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 161, DateTimeKind.Local).AddTicks(3510));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 161, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 161, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 159, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 159, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 159, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(6431));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(8584));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5035));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5038));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5073));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5171));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5174));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5224));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5226));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5227));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5237));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5239));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5245));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5249));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5251));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5254));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5268));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5278));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5319));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5322));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5325));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5327));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5329));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5334));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5335));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5338));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5341));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2208));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 11, 11, 20, 50, 160, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.CreateIndex(
                name: "IX_UsualScheduleInsurances_ServiceSupplyInsuranceId",
                schema: "an",
                table: "UsualScheduleInsurances",
                column: "ServiceSupplyInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBranch_CityId",
                schema: "an",
                table: "InsuranceBranch",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceBranch_InsuranceId",
                schema: "an",
                table: "InsuranceBranch",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceService_InsuranceId",
                schema: "an",
                table: "InsuranceService",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleInsurance_ServiceSupplyInsuranceId",
                schema: "an",
                table: "ScheduleInsurance",
                column: "ServiceSupplyInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSupplyInsurance_InsuranceId",
                schema: "an",
                table: "ServiceSupplyInsurance",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSupplyInsurance_ServiceSupplyId",
                schema: "an",
                table: "ServiceSupplyInsurance",
                column: "ServiceSupplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PatientInsurance_PatientInsuranceId",
                schema: "an",
                table: "Appointment",
                column: "PatientInsuranceId",
                principalSchema: "an",
                principalTable: "PatientInsurance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInsurance_ServiceSupplyInsurance_ServiceSupplyInsuranceId",
                schema: "an",
                table: "PatientInsurance",
                column: "ServiceSupplyInsuranceId",
                principalSchema: "an",
                principalTable: "ServiceSupplyInsurance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInsurance_PatientPersonInfo_UserPatientId",
                schema: "an",
                table: "PatientInsurance",
                column: "UserPatientId",
                principalSchema: "an",
                principalTable: "PatientPersonInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsualScheduleInsurances_ServiceSupplyInsurance_ServiceSupplyInsuranceId",
                schema: "an",
                table: "UsualScheduleInsurances",
                column: "ServiceSupplyInsuranceId",
                principalSchema: "an",
                principalTable: "ServiceSupplyInsurance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PatientInsurance_PatientInsuranceId",
                schema: "an",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientInsurance_ServiceSupplyInsurance_ServiceSupplyInsuranceId",
                schema: "an",
                table: "PatientInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientInsurance_PatientPersonInfo_UserPatientId",
                schema: "an",
                table: "PatientInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_UsualScheduleInsurances_ServiceSupplyInsurance_ServiceSupplyInsuranceId",
                schema: "an",
                table: "UsualScheduleInsurances");

            migrationBuilder.DropTable(
                name: "DiseaseRecordsForm",
                schema: "an");

            migrationBuilder.DropTable(
                name: "InsuranceBranch",
                schema: "an");

            migrationBuilder.DropTable(
                name: "InsuranceService",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ScheduleInsurance",
                schema: "an");

            migrationBuilder.DropTable(
                name: "ServiceSupplyInsurance",
                schema: "an");

            migrationBuilder.DropIndex(
                name: "IX_UsualScheduleInsurances_ServiceSupplyInsuranceId",
                schema: "an",
                table: "UsualScheduleInsurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientInsurance",
                schema: "an",
                table: "PatientInsurance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurance",
                schema: "an",
                table: "Insurance");

            migrationBuilder.DropColumn(
                name: "CurrencyType",
                schema: "an",
                table: "ShiftCenterService");

            migrationBuilder.DropColumn(
                name: "Note",
                schema: "an",
                table: "ShiftCenterService");

            migrationBuilder.DropColumn(
                name: "Note_Ar",
                schema: "an",
                table: "ShiftCenterService");

            migrationBuilder.DropColumn(
                name: "Note_Ku",
                schema: "an",
                table: "ShiftCenterService");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "an",
                table: "ShiftCenterService");

            migrationBuilder.DropColumn(
                name: "PriceWithDiscount",
                schema: "an",
                table: "ShiftCenterService");

            migrationBuilder.DropColumn(
                name: "DiscountPercentange",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Photo_Ar",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Photo_Ku",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Summary",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Summary_Ar",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Summary_Ku",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Title_Ar",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Title_Ku",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "VisitsCount",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Logo",
                schema: "an",
                table: "Hospital");

            migrationBuilder.DropColumn(
                name: "Logo",
                schema: "an",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "Logo",
                schema: "an",
                table: "Insurance");

            migrationBuilder.RenameTable(
                name: "PatientInsurance",
                schema: "an",
                newName: "PatientInsurances",
                newSchema: "an");

            migrationBuilder.RenameTable(
                name: "Insurance",
                schema: "an",
                newName: "Insurances",
                newSchema: "an");

            migrationBuilder.RenameColumn(
                name: "ServiceSupplyInsuranceId",
                schema: "an",
                table: "UsualScheduleInsurances",
                newName: "InsuranceId");

            migrationBuilder.RenameColumn(
                name: "ServiceSupplyInsuranceId",
                schema: "an",
                table: "PatientInsurances",
                newName: "InsuranceId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientInsurance_UserPatientId",
                schema: "an",
                table: "PatientInsurances",
                newName: "IX_PatientInsurances_UserPatientId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientInsurance_ServiceSupplyInsuranceId",
                schema: "an",
                table: "PatientInsurances",
                newName: "IX_PatientInsurances_InsuranceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name_Ku",
                schema: "an",
                table: "Insurances",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Name_Ar",
                schema: "an",
                table: "Insurances",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "an",
                table: "Insurances",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Ku",
                schema: "an",
                table: "Insurances",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Ar",
                schema: "an",
                table: "Insurances",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "an",
                table: "Insurances",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UsualScheduleInsurances_InsuranceId_ScheduleId",
                schema: "an",
                table: "UsualScheduleInsurances",
                columns: new[] { "InsuranceId", "ScheduleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientInsurances",
                schema: "an",
                table: "PatientInsurances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurances",
                schema: "an",
                table: "Insurances",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 32, DateTimeKind.Local).AddTicks(9786));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 32, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 32, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 34, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 34, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 34, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 34, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 34, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 34, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 34, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 32, DateTimeKind.Local).AddTicks(3455));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 32, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 32, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(6897));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5426));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5462));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5469));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5471));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5472));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5475));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5477));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5479));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5504));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5537));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5538));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5543));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5546));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5558));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5559));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5571));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5574));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5585));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5587));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5648));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5651));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5678));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5680));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5692));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5694));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5702));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5708));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5722));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5734));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5736));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5753));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5794));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5798));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5801));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5804));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5815));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5818));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PatientInsurances_PatientInsuranceId",
                schema: "an",
                table: "Appointment",
                column: "PatientInsuranceId",
                principalSchema: "an",
                principalTable: "PatientInsurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInsurances_Insurances_InsuranceId",
                schema: "an",
                table: "PatientInsurances",
                column: "InsuranceId",
                principalSchema: "an",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInsurances_PatientPersonInfo_UserPatientId",
                schema: "an",
                table: "PatientInsurances",
                column: "UserPatientId",
                principalSchema: "an",
                principalTable: "PatientPersonInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsualScheduleInsurances_Insurances_InsuranceId",
                schema: "an",
                table: "UsualScheduleInsurances",
                column: "InsuranceId",
                principalSchema: "an",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
