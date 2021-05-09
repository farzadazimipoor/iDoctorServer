using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class ServiceSupplyInfoPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "an",
                table: "ServiceSupplyInfo",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 815, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 815, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 815, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 815, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 815, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 812, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 812, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 812, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(828));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1131));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1136));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1138));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1229));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1244));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1257));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1272));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1300));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1319));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1382));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1390));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1419));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1446));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1474));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1491));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1495));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1538));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 814, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7904));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7907));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7921));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7923));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 16, 17, 0, 46, 813, DateTimeKind.Local).AddTicks(7995));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "an",
                table: "ServiceSupplyInfo");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 846, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 846, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 846, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 845, DateTimeKind.Local).AddTicks(8741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 845, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 845, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 845, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 843, DateTimeKind.Local).AddTicks(5273));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 843, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 843, DateTimeKind.Local).AddTicks(5937));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 845, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 845, DateTimeKind.Local).AddTicks(3546));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 845, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(8393));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9244));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9414));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9491));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9506));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9521));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9573));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9585));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9586));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9589));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9601));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9612));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9615));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9618));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9621));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9625));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9627));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9634));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9649));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9695));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9696));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9698));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9699));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9704));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9707));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9742));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9778));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5662));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5715));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5718));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5724));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5726));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5734));
        }
    }
}
