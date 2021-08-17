using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class ServicePriceString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                schema: "an",
                table: "ShiftCenterService",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(19,4)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(3176));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(3205));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(5086));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(5337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(5345));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(6474));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(3793));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(1176));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 709, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(8819));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 711, DateTimeKind.Local).AddTicks(307));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7324));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7429));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7432));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7439));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7444));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7461));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7500));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7582));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7587));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7609));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7673));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7687));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7815));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5187) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5189) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5190) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5192) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5194) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5196) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5197) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 4, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5199) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 16, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5200) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2048, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5202) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2048, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5204) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2048, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5205) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2048, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5207) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2048, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5208) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2048, new DateTime(2021, 8, 17, 10, 8, 13, 710, DateTimeKind.Local).AddTicks(5210) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "an",
                table: "ShiftCenterService",
                type: "decimal(19,4)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 37, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 37, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 37, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 37, DateTimeKind.Local).AddTicks(1341));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 37, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(6227));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 35, DateTimeKind.Local).AddTicks(6229));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4713));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4745));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4773));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4779));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4882));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4989));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4992));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5005));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5013));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5015));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5019));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5022));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5024));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5035));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5092));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5126));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5142));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 0, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2456) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2479) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2481) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2483) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2484) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2486) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2487) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 1, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2489) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 2, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2491) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 4, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2492) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 14, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2494) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 14, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2495) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 14, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2497) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 14, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2498) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 14, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2500) });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CenterType", "CreatedAt" },
                values: new object[] { 14, new DateTime(2021, 8, 1, 16, 17, 50, 36, DateTimeKind.Local).AddTicks(2502) });
        }
    }
}
