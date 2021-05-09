using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class offerNotiftitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificationBody",
                schema: "an",
                table: "Offer",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationBody_Ar",
                schema: "an",
                table: "Offer",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationBody_Ku",
                schema: "an",
                table: "Offer",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationTitle",
                schema: "an",
                table: "Offer",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationTitle_Ar",
                schema: "an",
                table: "Offer",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationTitle_Ku",
                schema: "an",
                table: "Offer",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SendNotification",
                schema: "an",
                table: "Offer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 360, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 360, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 360, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 360, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 360, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(1390));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(6063));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2404));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2608));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2627));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2699));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2715));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2718));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2729));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2743));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9807));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9809));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 4, 14, 17, 57, 358, DateTimeKind.Local).AddTicks(9816));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationBody",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "NotificationBody_Ar",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "NotificationBody_Ku",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "NotificationTitle",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "NotificationTitle_Ar",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "NotificationTitle_Ku",
                schema: "an",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "SendNotification",
                schema: "an",
                table: "Offer");

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(3184));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(3187));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 157, DateTimeKind.Local).AddTicks(8897));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 158, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 158, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 157, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 157, DateTimeKind.Local).AddTicks(7633));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 157, DateTimeKind.Local).AddTicks(3506));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 157, DateTimeKind.Local).AddTicks(5174));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 155, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 155, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 155, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 157, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 157, DateTimeKind.Local).AddTicks(2433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 157, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8924));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8963));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8965));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8967));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8969));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8994));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(8996));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9012));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9013));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9024));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9026));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9038));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5989));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5991));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 29, 6, 42, 8, 156, DateTimeKind.Local).AddTicks(5992));
        }
    }
}
