using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class ConsultancyMessageSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sender",
                schema: "an",
                table: "ConsultancyMessage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 657, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 657, DateTimeKind.Local).AddTicks(8361));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 657, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 660, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 660, DateTimeKind.Local).AddTicks(5693));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 660, DateTimeKind.Local).AddTicks(5712));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 660, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 660, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 659, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 659, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 655, DateTimeKind.Local).AddTicks(5964));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 655, DateTimeKind.Local).AddTicks(6896));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 655, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 659, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 659, DateTimeKind.Local).AddTicks(1342));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6079));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6127));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6130));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6134));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6136));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6138));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6174));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6177));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6227));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6235));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2304));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 15, 1, 53, 658, DateTimeKind.Local).AddTicks(2319));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sender",
                schema: "an",
                table: "ConsultancyMessage");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 332, DateTimeKind.Local).AddTicks(3465));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 332, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 328, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 328, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 328, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(5244));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 332, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 332, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3513));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3547));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3580));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3671));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3673));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3681));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3715));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9480));
        }
    }
}
