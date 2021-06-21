using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class AppointmentProgressAndRatingReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.AddColumn<string>(
                name: "Review",
                schema: "an",
                table: "ServiceSupplyRating",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgressStatus",
                schema: "an",
                table: "Appointment",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(7172));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 329, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 329, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 329, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 329, DateTimeKind.Local).AddTicks(9281));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 332, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 332, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(5404));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(6473));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(2724));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(2947));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1506));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1512));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1525));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1568));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1580));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1585));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1587));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1588));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1592));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1625));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1627));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1641));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1657));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1672));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1698));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1733));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1735));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1737));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1743));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1803));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1828));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1838));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1843));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1861));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1923));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1943));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1948));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1953));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1974));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1989));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 331, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9228));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9239));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9241));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9248));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 21, 17, 14, 42, 330, DateTimeKind.Local).AddTicks(9252));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                schema: "an",
                table: "ServiceSupplyRating");

            migrationBuilder.DropColumn(
                name: "ProgressStatus",
                schema: "an",
                table: "Appointment");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(5237));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(5264));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(5267));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 221, DateTimeKind.Local).AddTicks(6901));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 221, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 221, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 221, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(8462));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(5847));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(643));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(857));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 223, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9356));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9506));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9664));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9665));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9717));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9726));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9755));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9758));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9782));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9792));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9872));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9883));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9886));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.InsertData(
                schema: "an",
                table: "ServiceCategory",
                columns: new[] { "Id", "CenterType", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "Photo", "UpdatedAt" },
                values: new object[,]
                {
                    { 12, 11, new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7237), false, "Hair", "الشعر", "پرچ", null, null },
                    { 11, 11, new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7236), false, "Makeup", "مكياج", "مكياج", null, null },
                    { 10, 11, new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7234), false, "Face", "الوجه", "دەموچاو", null, null },
                    { 14, 11, new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7241), false, "Nail", "الأضافر", "نینۆک", null, null },
                    { 13, 11, new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(7239), false, "Laser", "ليزر", "لەیز‌ەر", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9571));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9573));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9586));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9589));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9601));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9612));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9615));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9618));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(9647));
        }
    }
}
