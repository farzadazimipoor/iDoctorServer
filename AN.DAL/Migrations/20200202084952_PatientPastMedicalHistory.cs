using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class PatientPastMedicalHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PastMedicalHistory",
                schema: "an",
                columns: table => new
                {
                    TreatmentHistoryId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PresentIllness = table.Column<string>(maxLength: 500, nullable: true),
                    PastMedical = table.Column<string>(maxLength: 500, nullable: true),
                    DrugHistory = table.Column<string>(maxLength: 500, nullable: true),
                    SocialHistory = table.Column<string>(maxLength: 500, nullable: true),
                    ExaminationHistory = table.Column<string>(maxLength: 500, nullable: true),
                    SignsAndSymptomsHistory = table.Column<string>(maxLength: 500, nullable: true),
                    SurgicalHistory = table.Column<string>(maxLength: 500, nullable: true),
                    FamilyHistory = table.Column<string>(maxLength: 500, nullable: true),
                    SystemicReview = table.Column<string>(maxLength: 500, nullable: true),
                    DifferentialDiagnosis = table.Column<string>(maxLength: 500, nullable: true),
                    FinalDiagnosis = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastMedicalHistory", x => x.TreatmentHistoryId);
                    table.ForeignKey(
                        name: "FK_PastMedicalHistory_TreatmentHistory_TreatmentHistoryId",
                        column: x => x.TreatmentHistoryId,
                        principalSchema: "an",
                        principalTable: "TreatmentHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(981));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(971));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(1639));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(5819));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3117));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3123));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3191));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(56));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(89));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(92));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PastMedicalHistory",
                schema: "an");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(1943));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(5489));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 970, DateTimeKind.Local).AddTicks(5513));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 970, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 970, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 972, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7668));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7809));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7810));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7824));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(4751));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(4753));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(4755));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(4757));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(4759));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 27, 13, 9, 6, 971, DateTimeKind.Local).AddTicks(4762));
        }
    }
}
