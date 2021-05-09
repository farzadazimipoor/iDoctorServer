using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class homecareservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name_Ku",
                schema: "an",
                table: "Service",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name_Ar",
                schema: "an",
                table: "Service",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "an",
                table: "Service",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(6404));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(6433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 786, DateTimeKind.Local).AddTicks(3731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 786, DateTimeKind.Local).AddTicks(4410));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 786, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(8838));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 788, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7246));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7257));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7292));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7361));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7393));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7406));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7419));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7473));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7488));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7500));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7562));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7598));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7603));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4192));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4225));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4228));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4235));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4238));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.InsertData(
                schema: "an",
                table: "ServiceCategory",
                columns: new[] { "Id", "CenterType", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "Photo", "UpdatedAt" },
                values: new object[,]
                {
                    { 16, 14, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4243), false, "Covid-19 Services", "خدمات كوفيد-١٩", "خزمەتگوزارییەکانی تایبەت بە کۆڤید", null, null },
                    { 17, 14, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4245), false, "Normal Case Services Non-Covid Cases", "الحالات غير المقدمة لخدمات الحالات العادية", "خزمەتگوزارییەکانی تایبەت بە نەخۆشی ئاسایی", null, null },
                    { 18, 14, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4247), false, "Ambulance", "ئەمبوڵانس", "ئەمبولانس", null, null },
                    { 19, 14, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4249), false, "Physiotherapy", "العلاج الطبيعي", "چاره‌سه‌ری سروشتی", null, null },
                    { 20, 14, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4250), false, "Laboratory", "المختبر", "پشکنینی خوێن", null, null },
                    { 21, 14, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4252), false, "Medicines", "الادويه", "دەرمان", null, null }
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ServiceCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 91, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7621), false, "Specialist Consultation", "استشارة متخصصة", "ڕاوێژكاری پزیشكی پسپۆر", 16, null },
                    { 116, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7691), false, "Regular Case", "حالة عادية", "كەیسی ئاسایی", 19, null },
                    { 115, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7690), false, "Chronic Case", "الحالة المزمنة", "كەیسی درێژخایەن", 19, null },
                    { 114, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7688), false, "Defficult Case", "حالة صعبة", "كەیسی سەخت", 19, null },
                    { 113, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7678), false, "Nurse inside Ambulance-Extra", "ممرضة داخل الإسعاف اضافية", "نێرس بۆ ناو ئەمبولانس", 18, null },
                    { 112, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7676), false, "Ambulance Normal Case Non-Covid", "ئەمبوڵانس کۆڤید لەگەڵ ستاف + سی-پاپ + مۆنیتەر", "ئەمبولانس - ئاسایی", 18, null },
                    { 111, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7675), false, "Ambulance Covid With Staff+ C-Pap + Monitor", "سيارة إسعاف خاص بالمشخص بكوفيد ١٩ + موظفين + C-pap", "ئەمبولانس تایبەت بە توشبووی كۆڤید + ستاف + مراقبة +  C-Pap", 18, null },
                    { 110, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7663), false, "Healthy Food Schedule", "جدول الغذاء الصحي", "دانانی خشتەی خۆراكی تەندروست لەلایەن پزیشكی پسپۆر", 17, null },
                    { 109, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7660), false, "Fluid Aspiration", "سحب الماء من الرئة", "دەرهێنانی ئاوی زیادەی سنگ", 17, null },
                    { 108, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7659), false, "ECG Holter with Cardiologysts Report", "تخطيط القلب الكهربائي مع تقرير أطباء القلب", "هێلكاری دڵی ٢٤ كاتژمێری لەگەڵ راپۆرتی پزیشكی پسپۆر", 17, null },
                    { 107, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7657), false, "Monitoring", "جهاز المراقبة", "ئامێری مۆنیتەر", 17, null },
                    { 106, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7656), false, "Nebulizer", "بخار", "هەڵم", 17, null },
                    { 105, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7654), false, "Fluid suction", "شفط السوائل", "سۆنده‌ی کێشان", 17, null },
                    { 104, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7653), false, "Dressing", "ضماد", "تیماركردنی برین", 17, null },
                    { 103, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7651), false, "NG Tube", "انبوب انفي معدي", "دانانی سۆندەی خۆراك", 17, null },
                    { 102, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7649), false, "Foley Catheter & Remove Catheter", "ادراج قثطار فولي", "دانانی سۆندەی میز", 17, null },
                    { 101, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7648), false, "Injection", "حقن  ", "دەرزی لێدان", 17, null },
                    { 100, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7646), false, "Insert Cannula", "إدراج كانولا", "دانانی كانولا", 17, null },
                    { 99, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7645), false, "ECG", "تخطيط القلب الكهربائي", "هێلكاری لێدانی دڵ", 17, null },
                    { 98, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7643), false, "Nurse Follow-Up- 24 Hour", "متابعة الممرضة - ٢٤ ساعة", "چاودێری ٢٤ کاتژمێر", 17, null },
                    { 97, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7641), false, "Nurse Follow-Up By Hour", "متابعة الممرضة حسب الساعة", "چاودێری نێرس بەپێی کات", 17, null },
                    { 96, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7640), false, "Specialist Consultation", "استشارة متخصصة", "ڕاوێژكاری پزیشكی پسپۆر", 17, null },
                    { 95, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7628), false, "Bottle Oxygen- oxygen maker", "زجاجة الأكسجين- صانع الأكسجين", "بتڵ ئۆكسجین + ئامێری ئۆكسجین", 16, null },
                    { 94, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7626), false, "Medication", "إعطاء الدواء", "پێدانی دەرمان", 16, null },
                    { 93, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7625), false, "24 hour Nurse Follow-Up +1 Bottle Oxigen", "متابعة ممرضة على مدار ٢٤ ساعة + ١ زجاجة أكسجين", "چاودێری ٢٤ كاتژمێر  - ستافی تایبەتمەند + ١ بتڵ ئۆكسجین", 16, null },
                    { 92, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7623), false, "24 hour Nurse Follow-Up +1 Bottle Oxigen + C-Pap", "متابعة ممرضة على مدار ٢٤ ساعة +١ زجاجة أكسجين + C-Pap", "چاودێری ٢٤ كاتژمێر - ستافی تایبەتمەند + ١ بتڵ ئۆكسجین + C-Pap", 16, null },
                    { 117, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7701), false, "The blood will be taken in your home, and the  result will be received at home", "الدم سوف يؤخذ في منزلك، والنتيجة سوف تستلم في المنزل", "ستافی تایبەتمەند هاڵدەستێ بە وەرگرتنی خوێن لەناو ماڵەکانتان، و ئەنجامەکەی دەگەڕێتەوە بۆ ماڵەکانتان", 20, null },
                    { 118, new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7711), false, "You will receive medicines recomanded by the specialists in your home", "سوف تتلقى الأدوية التي يوصي بها المتخصصون في منزلك", "ئەو دەرمانانەی کە لەلایەن پزیشکی پسپۆرەوە نوسراون، بۆتان دەگەیەنرێتە ناو ماڵەکانتان", 21, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.AlterColumn<string>(
                name: "Name_Ku",
                schema: "an",
                table: "Service",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name_Ar",
                schema: "an",
                table: "Service",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "an",
                table: "Service",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(1799));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 314, DateTimeKind.Local).AddTicks(8399));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 315, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 315, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 314, DateTimeKind.Local).AddTicks(7076));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 314, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 314, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 314, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 312, DateTimeKind.Local).AddTicks(4121));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 312, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 312, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 314, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 314, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7786));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7788));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7793));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7799));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7803));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7806));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7873));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7904));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7954));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8076));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8078));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8086));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4748));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4779));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4784));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4794));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 25, 13, 9, 57, 313, DateTimeKind.Local).AddTicks(4797));
        }
    }
}
