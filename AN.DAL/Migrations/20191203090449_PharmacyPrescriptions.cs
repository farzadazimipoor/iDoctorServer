using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class PharmacyPrescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistory_Pharmacy_PharmacyId",
                schema: "an",
                table: "TreatmentHistory");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentHistory_PharmacyId",
                schema: "an",
                table: "TreatmentHistory");

            migrationBuilder.DropColumn(
                name: "PharmacyId",
                schema: "an",
                table: "TreatmentHistory");

            migrationBuilder.CreateTable(
                name: "PharmacyPrescriptions",
                schema: "an",
                columns: table => new
                {
                    TreatmentHistoryId = table.Column<int>(nullable: false),
                    PharmacyId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyPrescriptions", x => new { x.TreatmentHistoryId, x.PharmacyId });
                    table.UniqueConstraint("AK_PharmacyPrescriptions_PharmacyId_TreatmentHistoryId", x => new { x.PharmacyId, x.TreatmentHistoryId });
                    table.ForeignKey(
                        name: "FK_PharmacyPrescriptions_Pharmacy_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "an",
                        principalTable: "Pharmacy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PharmacyPrescriptions_TreatmentHistory_TreatmentHistoryId",
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
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(5574));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(5576));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(4763));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 807, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(181));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(2146));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(3775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1267));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1272));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1273));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1315));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1317));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1327));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1335));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1341));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1343));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 809, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 3, 12, 4, 48, 808, DateTimeKind.Local).AddTicks(8285));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyPrescriptions",
                schema: "an");

            migrationBuilder.AddColumn<int>(
                name: "PharmacyId",
                schema: "an",
                table: "TreatmentHistory",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(3421));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 949, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 949, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 949, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 949, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 947, DateTimeKind.Local).AddTicks(7361));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 947, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 947, DateTimeKind.Local).AddTicks(8027));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 949, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 949, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8824));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8827));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8833));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8837));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8838));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8913));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8915));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8925));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8927));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8931));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8936));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8938));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8939));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(6095));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(6124));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(6127));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 2, 11, 36, 48, 948, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistory_PharmacyId",
                schema: "an",
                table: "TreatmentHistory",
                column: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentHistory_Pharmacy_PharmacyId",
                schema: "an",
                table: "TreatmentHistory",
                column: "PharmacyId",
                principalSchema: "an",
                principalTable: "Pharmacy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
