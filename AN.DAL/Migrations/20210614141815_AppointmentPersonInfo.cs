using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace AN.DAL.Migrations
{
    public partial class AppointmentPersonInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeCareDescription",
                schema: "an",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeCareDescription_Ar",
                schema: "an",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeCareDescription_Ku",
                schema: "an",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<Point>(
                name: "PersonLocation",
                schema: "an",
                table: "Appointment",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(5956));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(5984));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(5986));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 750, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 750, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(6679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(6704));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(1522));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(1742));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(3196));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(158));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(235));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(237));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(301));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(303));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(329));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(346));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(357));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(373));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(378));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(383));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(407));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(432));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(459));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(463));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(466));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(467));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(477));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(553));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(561));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(565));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 752, DateTimeKind.Local).AddTicks(649));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7928));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7954));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7959));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7973));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7977));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 751, DateTimeKind.Local).AddTicks(7987));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeCareDescription",
                schema: "an",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "HomeCareDescription_Ar",
                schema: "an",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "HomeCareDescription_Ku",
                schema: "an",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "PersonLocation",
                schema: "an",
                table: "Appointment");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 143, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 143, DateTimeKind.Local).AddTicks(4023));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 147, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 147, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 147, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 143, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(5729));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6023));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6085));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6087));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6104));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6108));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6115));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6117));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6251));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6265));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6267));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6283));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6310));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6379));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6395));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6399));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6413));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6415));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6431));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6449));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6593));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1773));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1798));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1814));
        }
    }
}
