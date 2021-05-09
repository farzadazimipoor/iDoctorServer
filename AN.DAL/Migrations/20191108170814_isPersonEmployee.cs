using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class isPersonEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmployee",
                schema: "an",
                table: "Person",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 69, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 69, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 69, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(2737));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 66, DateTimeKind.Local).AddTicks(8627));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 66, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 66, DateTimeKind.Local).AddTicks(9857));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7039));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7042));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7196));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2698));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmployee",
                schema: "an",
                table: "Person");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(636));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 824, DateTimeKind.Local).AddTicks(728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 824, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(7176));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 819, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 819, DateTimeKind.Local).AddTicks(1974));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 819, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(842));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 823, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9522));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4773));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 19, 58, 3, 822, DateTimeKind.Local).AddTicks(4836));
        }
    }
}
