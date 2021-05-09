using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class PatientHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistory_Person_PersonId",
                schema: "an",
                table: "TreatmentHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistory_ServiceSupply_ServiceSupplyId",
                schema: "an",
                table: "TreatmentHistory");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentHistory_PersonId",
                schema: "an",
                table: "TreatmentHistory");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "an",
                table: "TreatmentHistory");

            migrationBuilder.RenameColumn(
                name: "ServiceSupplyId",
                schema: "an",
                table: "TreatmentHistory",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentHistory_ServiceSupplyId",
                schema: "an",
                table: "TreatmentHistory",
                newName: "IX_TreatmentHistory_PatientId");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 441, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 440, DateTimeKind.Local).AddTicks(1929));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 440, DateTimeKind.Local).AddTicks(5435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 434, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 435, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 435, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4436));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4505));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4652));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4663));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4738));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 439, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8774));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 21, 13, 14, 438, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentHistory_Patients_PatientId",
                schema: "an",
                table: "TreatmentHistory",
                column: "PatientId",
                principalSchema: "an",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistory_Patients_PatientId",
                schema: "an",
                table: "TreatmentHistory");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                schema: "an",
                table: "TreatmentHistory",
                newName: "ServiceSupplyId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentHistory_PatientId",
                schema: "an",
                table: "TreatmentHistory",
                newName: "IX_TreatmentHistory_ServiceSupplyId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                schema: "an",
                table: "TreatmentHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(2697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(2731));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(3966));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 785, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 785, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 785, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 787, DateTimeKind.Local).AddTicks(1352));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8575));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8589));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8591));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8602));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8604));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8616));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8644));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(5581));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(5618));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 18, 16, 48, 49, 786, DateTimeKind.Local).AddTicks(5619));

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistory_PersonId",
                schema: "an",
                table: "TreatmentHistory",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentHistory_Person_PersonId",
                schema: "an",
                table: "TreatmentHistory",
                column: "PersonId",
                principalSchema: "an",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentHistory_ServiceSupply_ServiceSupplyId",
                schema: "an",
                table: "TreatmentHistory",
                column: "ServiceSupplyId",
                principalSchema: "an",
                principalTable: "ServiceSupply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
