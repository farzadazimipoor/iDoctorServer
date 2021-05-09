using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class HealthyLifestyleServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                schema: "an",
                table: "ServiceCategory",
                columns: new[] { "Id", "CenterType", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[] { 15, 4, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(2549), false, "Healthy Lifestyle", "أنماط الحیاة صحي", "سەنتەری تەندروستی", null });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ServiceCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 69, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5747), false, "Visit", "زیارة العیادة", "سەردان کردن", 15, null },
                    { 88, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5815), false, "Joint dislocation", "خلع المفاصل", "لە جێ دەرچوونی جومگە", 15, null },
                    { 87, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5813), false, "Spinal cord dislocation", "خلع النخاع", "لە جێ دەرچوونی بڕبڕەی پشت", 15, null },
                    { 86, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5812), false, "Children's hemiplegia treatment", "علاج فالج الأطفال", "چارەسەری ئیفلیجی منداڵان", 15, null },
                    { 85, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5810), false, "Hemiplegia treatment", "علاج فالج", "چارەسەری ئیفلیجی", 15, null },
                    { 84, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5809), false, "Gluten Free", "بدون غلوتین", "خاڵی لە گلوتین/پێزە", 15, null },
                    { 83, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5807), false, "Lactose Free", "بدون لاکتوز", "خاڵی لە لەکتۆز", 15, null },
                    { 82, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5805), false, "Sugar free", "بدون سکر", "خاڵی لە شەکر", 15, null },
                    { 81, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5804), false, "Body Composition Analyzing", "تحلیل ترکیب الجسم", "شیکردنەوەی پێکهاتەی لەش", 15, null },
                    { 80, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5802), false, "Nutrition Consultation", "مشاورة التغذیة", "ڕاوێژی خۆراک", 15, null },
                    { 79, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5801), false, "Healthy Lifestyle", "أنماط الحیاة صحي", "شێوازی ژیانی تەندروست", 15, null },
                    { 78, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5799), false, "Stevia", "ستیڤیا", "ستێڤیا", 15, null },
                    { 77, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5798), false, "Ketogenic Diet Plan", "خطة نطام الغذائي کیتوجنیک", "پلانی ڕێجیمی کیتۆجێنیک", 15, null },
                    { 76, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5796), false, "Keto Diet", "نطام الغذائي کیتو", "ڕێجیمی کیتۆ", 15, null },
                    { 75, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5794), false, "Dukan Diet", "نطام الغذائي دوکان", "ڕێجیمی دوکان", 15, null },
                    { 74, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5754), false, "Atkins Diet", "نطام الغذائي آتکینز", "ڕێجیمی ئاتکینز", 15, null },
                    { 73, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5753), false, "Lifestyle Diets", "نطام الغذائي أنماط الحیاة", "ڕێجیمی شێوازی ژیان", 15, null },
                    { 72, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5751), false, "No Deprivation Diet", "نطام الغذائي بدون حرمان", "ڕێجیمی بێ نەقس", 15, null },
                    { 71, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5750), false, "Intermittent Fasting Diet", "نطام الغذائي صوم المتقطع", "ڕێجیمی پچڕ پچڕ", 15, null },
                    { 70, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5748), false, "Diet Clinic", "کلینیک نظام الغذائي", "کلینیکی پارێز کردن", 15, null },
                    { 89, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5816), false, "Physiotherapy", "العلاج الطبیعي", "چارەسەری سروشتی", 15, null },
                    { 90, new DateTime(2020, 9, 2, 9, 43, 22, 33, DateTimeKind.Local).AddTicks(5818), false, "Speaking problems", "مشاکل التکلم", "گرفتەکانی قسە کردن", 15, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 252, DateTimeKind.Local).AddTicks(8057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 252, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 252, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 254, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 254, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 254, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 254, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 254, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 254, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 251, DateTimeKind.Local).AddTicks(9564));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 252, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 252, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4023));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4122));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4129));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4144));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4165));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4199));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4201));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4215));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4235));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4238));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4253));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4275));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4277));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4281));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4341));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4343));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(4383));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1044));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 8, 47, 22, 253, DateTimeKind.Local).AddTicks(1069));
        }
    }
}
