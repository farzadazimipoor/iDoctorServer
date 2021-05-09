using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class ContentCategoryLayoutStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LayoutStyle",
                schema: "an",
                table: "ContentCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "an",
                table: "ContentArticle",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                schema: "an",
                table: "ContentArticle",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 766, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 766, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 766, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 768, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 769, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 769, DateTimeKind.Local).AddTicks(2075));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 768, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 768, DateTimeKind.Local).AddTicks(8399));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 768, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 768, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 765, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 766, DateTimeKind.Local).AddTicks(398));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 766, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(9695));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 768, DateTimeKind.Local).AddTicks(2433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 768, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6957));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6967));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7039));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7076));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7083));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7088));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7200));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 26, 8, 52, 36, 767, DateTimeKind.Local).AddTicks(1226));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LayoutStyle",
                schema: "an",
                table: "ContentCategory");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "an",
                table: "ContentArticle");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                schema: "an",
                table: "ContentArticle");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 72, DateTimeKind.Local).AddTicks(8721));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 72, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 72, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 74, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 74, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 74, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 74, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 74, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 74, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 72, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 72, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 72, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4336));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4342));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4343));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4355));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4404));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4407));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4412));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4502));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1512));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1515));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 16, 39, 7, 73, DateTimeKind.Local).AddTicks(1517));
        }
    }
}
