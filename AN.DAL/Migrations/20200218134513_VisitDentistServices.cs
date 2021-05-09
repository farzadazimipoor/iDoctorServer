using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class VisitDentistServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(8728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(5234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(5262));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(2741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 275, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 275, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 275, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 277, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7387));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7461));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7463));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.InsertData(
                schema: "an",
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ServiceCategoryId", "UpdatedAt" },
                values: new object[] { 43, new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(7546), false, "Visit", "يزور", "ڤیزیت", 9, null });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4341));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4343));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 18, 16, 45, 12, 276, DateTimeKind.Local).AddTicks(4346));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 851, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 851, DateTimeKind.Local).AddTicks(7359));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 851, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 854, DateTimeKind.Local).AddTicks(8445));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 855, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 855, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 854, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 854, DateTimeKind.Local).AddTicks(5708));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 853, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 854, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 848, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 848, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 848, DateTimeKind.Local).AddTicks(5735));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 853, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 853, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 853, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9065));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9074));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9356));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(2983));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 13, 0, 52, 46, 852, DateTimeKind.Local).AddTicks(3005));
        }
    }
}
