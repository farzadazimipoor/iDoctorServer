using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class ServiceSupplyExpertises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorExpertise_ServiceSupplyInfo_UserDoctorId",
                schema: "an",
                table: "DoctorExpertise");

            migrationBuilder.RenameColumn(
                name: "UserDoctorId",
                schema: "an",
                table: "DoctorExpertise",
                newName: "ServiceSupplyId");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(1935));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(9987));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(6448));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(6475));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 229, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 229, DateTimeKind.Local).AddTicks(5739));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 229, DateTimeKind.Local).AddTicks(5742));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 231, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7827));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7843));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4799));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 10, 9, 19, 32, 230, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorExpertise_ServiceSupply_ServiceSupplyId",
                schema: "an",
                table: "DoctorExpertise",
                column: "ServiceSupplyId",
                principalSchema: "an",
                principalTable: "ServiceSupply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorExpertise_ServiceSupply_ServiceSupplyId",
                schema: "an",
                table: "DoctorExpertise");

            migrationBuilder.RenameColumn(
                name: "ServiceSupplyId",
                schema: "an",
                table: "DoctorExpertise",
                newName: "UserDoctorId");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 184, DateTimeKind.Local).AddTicks(301));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 184, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 184, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(4989));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 181, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 181, DateTimeKind.Local).AddTicks(8785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 181, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(3954));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(493));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(525));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(535));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(566));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(604));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(639));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(642));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(644));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 183, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7409));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7416));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 11, 14, 41, 182, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorExpertise_ServiceSupplyInfo_UserDoctorId",
                schema: "an",
                table: "DoctorExpertise",
                column: "UserDoctorId",
                principalSchema: "an",
                principalTable: "ServiceSupplyInfo",
                principalColumn: "ServiceSupplyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
