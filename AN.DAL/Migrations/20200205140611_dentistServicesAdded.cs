using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class dentistServicesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 114, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 114, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 114, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 116, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 116, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 116, DateTimeKind.Local).AddTicks(5333));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 116, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 116, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 114, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 114, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 114, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3676));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3894));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3903));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3937));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3938));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3961));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3966));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3968));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4073));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4082));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(926));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(956));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.InsertData(
                schema: "an",
                table: "ServiceCategory",
                columns: new[] { "Id", "CenterType", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[] { 9, 2, new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(962), false, "Dentist", "Dentist", "ددان", null });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ServiceCategoryId", "UpdatedAt" },
                values: new object[] { 41, new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4093), false, "Complete examination", "Complete examination", "پشکنینی گشتی", 9, null });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ServiceCategoryId", "UpdatedAt" },
                values: new object[] { 42, new DateTime(2020, 2, 5, 17, 6, 10, 115, DateTimeKind.Local).AddTicks(4095), false, "Dental cleanings", "Dental cleanings", "خاوێن کردنەوەی ددان", 9, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 914, DateTimeKind.Local).AddTicks(981));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(971));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 912, DateTimeKind.Local).AddTicks(1639));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(5819));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3117));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3123));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3191));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(56));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(89));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 2, 11, 49, 51, 913, DateTimeKind.Local).AddTicks(92));
        }
    }
}
