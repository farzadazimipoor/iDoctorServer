using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class MedicalRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "an",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CountryName",
                schema: "an",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                schema: "an",
                table: "Country");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                schema: "an",
                table: "Province",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "an",
                table: "Country",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "an",
                table: "Country",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                schema: "an",
                table: "Country",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ku",
                schema: "an",
                table: "Country",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MedicalRequest",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(maxLength: 1000, nullable: false),
                    RequestedCountryId = table.Column<int>(nullable: false),
                    RequesterPersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRequest_Country_RequestedCountryId",
                        column: x => x.RequestedCountryId,
                        principalSchema: "an",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRequest_Person_RequesterPersonId",
                        column: x => x.RequesterPersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.InsertData(
                schema: "an",
                table: "Country",
                columns: new[] { "Id", "Code", "CreatedAt", "IsDeleted", "Latitude", "Longitude", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "TR", new DateTime(2021, 5, 1, 1, 58, 51, 143, DateTimeKind.Local).AddTicks(3515), false, null, null, "Turkey", "تركيا", "تورکیا", null },
                    { 2, "IN", new DateTime(2021, 5, 1, 1, 58, 51, 143, DateTimeKind.Local).AddTicks(4023), false, null, null, "India", "الهند", "هیند", null }
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 147, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 147, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 147, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 143, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 144, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 146, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(5729));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6023));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6085));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6087));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6104));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6108));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6115));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6117));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6251));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6265));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6267));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6283));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6310));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6379));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6395));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6399));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6413));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6415));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6431));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6449));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6451));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6593));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1773));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1798));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 1, 58, 51, 145, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryId",
                schema: "an",
                table: "Province",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRequest_RequestedCountryId",
                schema: "an",
                table: "MedicalRequest",
                column: "RequestedCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRequest_RequesterPersonId",
                schema: "an",
                table: "MedicalRequest",
                column: "RequesterPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Province_Country_CountryId",
                schema: "an",
                table: "Province",
                column: "CountryId",
                principalSchema: "an",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Province_Country_CountryId",
                schema: "an",
                table: "Province");

            migrationBuilder.DropTable(
                name: "MedicalRequest",
                schema: "an");

            migrationBuilder.DropIndex(
                name: "IX_Province_CountryId",
                schema: "an",
                table: "Province");

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "an",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "an",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "an",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                schema: "an",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Name_Ku",
                schema: "an",
                table: "Country");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "an",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                schema: "an",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                schema: "an",
                table: "Country",
                nullable: false,
                defaultValue: 0);

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
    }
}
