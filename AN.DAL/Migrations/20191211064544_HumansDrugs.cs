using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class HumansDrugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_Ku",
                schema: "an",
                table: "Drug",
                newName: "TradeName");

            migrationBuilder.RenameColumn(
                name: "Name_Ar",
                schema: "an",
                table: "Drug",
                newName: "GenericName_Ku");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "an",
                table: "Drug",
                newName: "GenericName_Ar");

            migrationBuilder.RenameColumn(
                name: "CommercialName",
                schema: "an",
                table: "Drug",
                newName: "GenericName");

            migrationBuilder.AddColumn<string>(
                name: "ATCCode1",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ATCCode2",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DosageForm",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalStatus",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageSize",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageType",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RouteOfAdministration",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShelfLifeInMonth",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageConditions",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrengthVaue",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitOfStrength",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitOfVolume",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Volume",
                schema: "an",
                table: "Drug",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "GenericName", "TradeName" },
                values: new object[] { new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(6991), "Amoxil", "Amoxicillin" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "GenericName", "TradeName" },
                values: new object[] { new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(9215), "Neurontin", "Gabapentin" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "GenericName", "TradeName" },
                values: new object[] { new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(9231), "Motrin", "Ibuprofen" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(5732));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 132, DateTimeKind.Local).AddTicks(5859));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 132, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 132, DateTimeKind.Local).AddTicks(6529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 134, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7951));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7954));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(8086));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 11, 9, 45, 44, 133, DateTimeKind.Local).AddTicks(5074));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATCCode1",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "ATCCode2",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "DosageForm",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "LegalStatus",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "PackageSize",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "PackageType",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "RouteOfAdministration",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "ShelfLifeInMonth",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "StorageConditions",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "StrengthVaue",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "UnitOfStrength",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "UnitOfVolume",
                schema: "an",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "Volume",
                schema: "an",
                table: "Drug");

            migrationBuilder.RenameColumn(
                name: "TradeName",
                schema: "an",
                table: "Drug",
                newName: "Name_Ku");

            migrationBuilder.RenameColumn(
                name: "GenericName_Ku",
                schema: "an",
                table: "Drug",
                newName: "Name_Ar");

            migrationBuilder.RenameColumn(
                name: "GenericName_Ar",
                schema: "an",
                table: "Drug",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GenericName",
                schema: "an",
                table: "Drug",
                newName: "CommercialName");

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

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CommercialName", "CreatedAt", "Name_Ku" },
                values: new object[] { "Amoxicillin", new DateTime(2019, 12, 4, 12, 54, 13, 49, DateTimeKind.Local).AddTicks(3305), "Amoxil" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommercialName", "CreatedAt", "Name_Ku" },
                values: new object[] { "Gabapentin", new DateTime(2019, 12, 4, 12, 54, 13, 49, DateTimeKind.Local).AddTicks(5409), "Neurontin" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommercialName", "CreatedAt", "Name_Ku" },
                values: new object[] { "Ibuprofen", new DateTime(2019, 12, 4, 12, 54, 13, 49, DateTimeKind.Local).AddTicks(5426), "Motrin" });

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
    }
}
