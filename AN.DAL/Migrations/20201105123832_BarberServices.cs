using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class BarberServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                schema: "an",
                table: "ServiceCategory",
                columns: new[] { "Id", "CenterType", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "Photo", "UpdatedAt" },
                values: new object[] { 22, 13, new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(5734), false, "Barber", "حلاق", "سەرتاش", null, null });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ServiceCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 119, new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9773), false, "Haircut", "قصة شعر", "سەر چاککردن", 22, null },
                    { 120, new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9775), false, "Complete haircut", "قصة شعر کامل", "سەرچاککردنی کامل", 22, null },
                    { 121, new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9776), false, "Groom services", "خدمات العریس", "خزمەتگوزارییەکانی زاوا", 22, null },
                    { 122, new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9778), false, "Beard trimming", "تقليم اللحية", "ڕیش تاشین", 22, null },
                    { 123, new DateTime(2020, 11, 5, 15, 38, 31, 844, DateTimeKind.Local).AddTicks(9779), false, "Massage", "تدلیک", "مەساج", 22, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 22);

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
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7623));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7625));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7645));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7646));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7690));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(7711));

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

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4243));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 28, 17, 31, 43, 787, DateTimeKind.Local).AddTicks(4252));
        }
    }
}
