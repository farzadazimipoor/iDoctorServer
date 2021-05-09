using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class prescriptionPatientExtraInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PatientVisitAge",
                schema: "an",
                table: "SonarPrescriptions",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PatientVisitHeight",
                schema: "an",
                table: "SonarPrescriptions",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PatientVisitWeight",
                schema: "an",
                table: "SonarPrescriptions",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PatientVisitAge",
                schema: "an",
                table: "PharmacyPrescriptions",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PatientVisitHeight",
                schema: "an",
                table: "PharmacyPrescriptions",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PatientVisitWeight",
                schema: "an",
                table: "PharmacyPrescriptions",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 498, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 498, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 498, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 500, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 500, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 500, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 500, DateTimeKind.Local).AddTicks(3255));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 500, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 500, DateTimeKind.Local).AddTicks(403));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 498, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 498, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 498, DateTimeKind.Local).AddTicks(2304));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(7578));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4667));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4669));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4671));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4676));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4677));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4704));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4730));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4732));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4735));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4738));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4742));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4744));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(4828));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 5, 16, 53, 17, 499, DateTimeKind.Local).AddTicks(1437));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientVisitAge",
                schema: "an",
                table: "SonarPrescriptions");

            migrationBuilder.DropColumn(
                name: "PatientVisitHeight",
                schema: "an",
                table: "SonarPrescriptions");

            migrationBuilder.DropColumn(
                name: "PatientVisitWeight",
                schema: "an",
                table: "SonarPrescriptions");

            migrationBuilder.DropColumn(
                name: "PatientVisitAge",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.DropColumn(
                name: "PatientVisitHeight",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.DropColumn(
                name: "PatientVisitWeight",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 676, DateTimeKind.Local).AddTicks(3562));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 676, DateTimeKind.Local).AddTicks(6426));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 676, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 676, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 676, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 672, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 672, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 672, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(5538));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(5555));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2139));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2145));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2149));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2315));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 675, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(8451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 26, 1, 19, 42, 674, DateTimeKind.Local).AddTicks(8461));
        }
    }
}
