using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class ServicePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "an",
                table: "Service",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Ar",
                schema: "an",
                table: "Service",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Ku",
                schema: "an",
                table: "Service",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "an",
                table: "Service",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                schema: "an",
                table: "Service",
                maxLength: 5,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 416, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 416, DateTimeKind.Local).AddTicks(8534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 416, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 418, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 418, DateTimeKind.Local).AddTicks(7226));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 418, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 418, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 418, DateTimeKind.Local).AddTicks(3654));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(9506));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 418, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 416, DateTimeKind.Local).AddTicks(901));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 416, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 416, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4617));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4628));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4630));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4663));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4704));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4752));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4754));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4755));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4757));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4759));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4763));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4764));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4766));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4769));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4783));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4866));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4882));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4911));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(4992));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(5006));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(5009));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1411));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1525));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1527));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1538));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 14, 13, 26, 28, 417, DateTimeKind.Local).AddTicks(1543));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "an",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Description_Ar",
                schema: "an",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Description_Ku",
                schema: "an",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "an",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Time",
                schema: "an",
                table: "Service");

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
    }
}
