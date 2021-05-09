using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class DrugsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 47, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 47, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 47, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.InsertData(
                schema: "an",
                table: "Drug",
                columns: new[] { "Id", "CommercialName", "ConsumptionTypes", "ConsumptionTypes_Ar", "ConsumptionTypes_Ku", "CreatedAt", "EffectMechanism", "EffectMechanism_Ar", "EffectMechanism_Ku", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "SideEffects", "SideEffects_Ar", "SideEffects_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Amoxicillin", null, null, null, new DateTime(2019, 12, 4, 12, 54, 13, 49, DateTimeKind.Local).AddTicks(3305), null, null, null, false, "Amoxil", "Amoxil", "Amoxil", null, null, null, null },
                    { 2, "Gabapentin", null, null, null, new DateTime(2019, 12, 4, 12, 54, 13, 49, DateTimeKind.Local).AddTicks(5409), null, null, null, false, "Neurontin", "Neurontin", "Neurontin", null, null, null, null },
                    { 3, "Ibuprofen", null, null, null, new DateTime(2019, 12, 4, 12, 54, 13, 49, DateTimeKind.Local).AddTicks(5426), null, null, null, false, "Motrin", "Motrin", "Motrin", null, null, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 49, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 49, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 47, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 47, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 47, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(7348));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4958));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4974));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4985));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4988));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(5001));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(2067));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 12, 54, 13, 48, DateTimeKind.Local).AddTicks(2070));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 214, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 214, DateTimeKind.Local).AddTicks(7622));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 214, DateTimeKind.Local).AddTicks(7625));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 216, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 216, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 214, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 214, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 214, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(5718));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(5732));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(2950));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3169));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3171));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3173));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3176));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3178));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3179));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3181));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3184));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3187));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3189));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3191));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3230));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3274));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3276));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3278));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3279));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3301));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3315));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3316));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3319));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(3331));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(345));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(373));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 4, 10, 11, 31, 215, DateTimeKind.Local).AddTicks(378));
        }
    }
}
