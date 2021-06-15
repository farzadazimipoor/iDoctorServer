using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class CountriesList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                 schema: "an",
                 table: "City",
                 keyColumn: "Id",
                 keyValue: 3,
                 column: "CreatedAt",
                 value: new DateTime(2021, 6, 15, 14, 58, 41, 222, DateTimeKind.Local).AddTicks(5267));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedAt", "Name", "Name_Ar", "Name_Ku" },
                values: new object[] { "DE", new DateTime(2021, 6, 15, 14, 58, 41, 221, DateTimeKind.Local).AddTicks(6901), "Germany", "ألمانيا", "ئاڵمانیا" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 14, 58, 41, 221, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.InsertData(
                schema: "an",
                table: "Country",
                columns: new[] { "Id", "Code", "CreatedAt", "HomeCareDescription", "HomeCareDescription_Ar", "HomeCareDescription_Ku", "IsDeleted", "Latitude", "Longitude", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, "TR", new DateTime(2021, 6, 15, 14, 58, 41, 221, DateTimeKind.Local).AddTicks(7150), null, null, null, false, null, null, "Turkey", "تركيا", "تورکیا", null },
                    { 4, "JO", new DateTime(2021, 6, 15, 14, 58, 41, 221, DateTimeKind.Local).AddTicks(7152), null, null, null, false, null, null, "Jordan", "اردن", "ئوردن", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 4);          

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedAt", "Name", "Name_Ar", "Name_Ku" },
                values: new object[] { "TR", new DateTime(2021, 6, 14, 17, 18, 14, 750, DateTimeKind.Local).AddTicks(7817), "Turkey", "تركيا", "تورکیا" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 14, 17, 18, 14, 750, DateTimeKind.Local).AddTicks(8136));
        }
    }
}
