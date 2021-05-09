using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class PharmacyPrescriptionKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PharmacyPrescriptions_PharmacyId_TreatmentHistoryId",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PharmacyPrescriptions",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "an",
                table: "PharmacyPrescriptions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PharmacyPrescriptions",
                schema: "an",
                table: "PharmacyPrescriptions",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 174, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 174, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 174, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 172, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 172, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 172, DateTimeKind.Local).AddTicks(5622));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(8674));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(8687));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6260));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6265));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6273));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6276));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6278));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6342));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6361));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6373));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6375));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(3355));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(3378));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(3385));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 9, 51, 11, 173, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyPrescriptions_PharmacyId",
                schema: "an",
                table: "PharmacyPrescriptions",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyPrescriptions_TreatmentHistoryId",
                schema: "an",
                table: "PharmacyPrescriptions",
                column: "TreatmentHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PharmacyPrescriptions",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PharmacyPrescriptions_PharmacyId",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PharmacyPrescriptions_TreatmentHistoryId",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "an",
                table: "PharmacyPrescriptions");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PharmacyPrescriptions_PharmacyId_TreatmentHistoryId",
                schema: "an",
                table: "PharmacyPrescriptions",
                columns: new[] { "PharmacyId", "TreatmentHistoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PharmacyPrescriptions",
                schema: "an",
                table: "PharmacyPrescriptions",
                columns: new[] { "TreatmentHistoryId", "PharmacyId" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 684, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 684, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 684, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 686, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 686, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(6739));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 684, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 684, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 684, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3392));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3431));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3476));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3489));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3492));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3543));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(712));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(735));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(739));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(744));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 9, 59, 685, DateTimeKind.Local).AddTicks(746));
        }
    }
}
