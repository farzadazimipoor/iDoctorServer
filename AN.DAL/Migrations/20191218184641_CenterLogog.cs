using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class CenterLogog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                schema: "an",
                table: "ShiftCenter",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 88, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 88, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 88, DateTimeKind.Local).AddTicks(6074));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 87, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 87, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 87, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 81, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 81, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 81, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(3477));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(6898));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(6923));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1694));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1715));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1726));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1904));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1910));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1969));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1994));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 86, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 46, 39, 85, DateTimeKind.Local).AddTicks(5930));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                schema: "an",
                table: "ShiftCenter");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 440, DateTimeKind.Local).AddTicks(1929));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 440, DateTimeKind.Local).AddTicks(5435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 434, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 435, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 435, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4436));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4505));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4652));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4663));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4738));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8779));
        }
    }
}
