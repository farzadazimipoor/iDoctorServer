using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class NotificationOtherLangs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description_Ar",
                schema: "an",
                table: "Notifications",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Ku",
                schema: "an",
                table: "Notifications",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text_Ar",
                schema: "an",
                table: "Notifications",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text_Ku",
                schema: "an",
                table: "Notifications",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_Ar",
                schema: "an",
                table: "Notifications",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_Ku",
                schema: "an",
                table: "Notifications",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(5073));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 758, DateTimeKind.Local).AddTicks(961));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 758, DateTimeKind.Local).AddTicks(3176));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 758, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(9629));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 755, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 755, DateTimeKind.Local).AddTicks(8991));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 755, DateTimeKind.Local).AddTicks(8993));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(4455));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(664));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(884));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(885));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(892));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(893));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(897));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(954));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(956));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(971));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(981));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(984));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(996));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1000));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1026));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1028));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 757, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(8018));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 23, 9, 6, 31, 756, DateTimeKind.Local).AddTicks(8024));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_Ar",
                schema: "an",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Description_Ku",
                schema: "an",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Text_Ar",
                schema: "an",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Text_Ku",
                schema: "an",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Title_Ar",
                schema: "an",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Title_Ku",
                schema: "an",
                table: "Notifications");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(1246));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(5322));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(5348));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 316, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 316, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 316, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(369));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 318, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6916));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6918));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6919));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6921));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6923));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6928));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6931));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6933));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6934));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6988));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7022));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7025));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7027));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7042));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7044));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7084));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(7086));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4059));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4064));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4067));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4069));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 20, 16, 21, 40, 317, DateTimeKind.Local).AddTicks(4071));
        }
    }
}
