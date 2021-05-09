using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class SalonServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 721, DateTimeKind.Local).AddTicks(8905));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 721, DateTimeKind.Local).AddTicks(8936));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 721, DateTimeKind.Local).AddTicks(8939));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 723, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 723, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 723, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 723, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 723, DateTimeKind.Local).AddTicks(3286));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 723, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 721, DateTimeKind.Local).AddTicks(2777));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 721, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 721, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4535), "هەڵگرتنی مووی دەمو چاو" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4537), "برۆ کردن" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4546), "تاتۆی برۆ" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4550), "ئێکستێنشنی برۆ" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4571), "مکیاج کامل" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4573), "مکیاجی سادە" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4596), "کیراتین" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4623), "ماسک" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4624), "چارەسەری قژ وەرین" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4626), "چاندنی پرچ" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4628), "ئیکستێنشن" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4630), "ڕەنگ کردن" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4632), "ڕازاندنەوەی قژ" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4633), "ڕەنگ کردنی ڕیشەی قژ" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4635), "قژ بڕین" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4636), "سێشوار" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4640), "ئۆمبر" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4654), "تەواوی لەش" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4655), "دەمو چاو" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4666), "مانیکیور" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4668), "پێدیکیور" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4670), "جێل" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4671), "ئاکریلیک" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4693));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1726));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.InsertData(
                schema: "an",
                table: "ServiceCategory",
                columns: new[] { "Id", "CenterType", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "UpdatedAt" },
                values: new object[,]
                {
                    { 10, 11, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1731), false, "Face", "الوجه", "دەموچاو", null },
                    { 11, 11, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1733), false, "Makeup", "مكياج", "مكياج", null },
                    { 12, 11, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1734), false, "Hair", "الشعر", "پرچ", null },
                    { 13, 11, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1736), false, "Laser", "ليزر", "لەیز‌ەر", null },
                    { 14, 11, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(1737), false, "Nail", "الأضافر", "نینۆک", null }
                });

            migrationBuilder.InsertData(
                schema: "an",
                table: "Service",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Name_Ar", "Name_Ku", "ServiceCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 44, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4706), false, "Thread face lifting", "شد الوجه بالخيوط", "Thread face lifting", 10, null },
                    { 66, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4797), false, "Pedicure", "بديكير", "پێدیکیور", 14, null },
                    { 65, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4795), false, "Manicure", "منيكير", "مانیکیور", 14, null },
                    { 64, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4785), false, "Face", "الوجه", "دەمو چاو", 13, null },
                    { 63, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4783), false, "Full body", "كامل الجسم", "تەواوی لەش", 13, null },
                    { 62, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4770), false, "Ombre", "اونبرة", "ئۆمبر", 12, null },
                    { 61, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4769), false, "Acrylic/Mohair", "موهير", "موهير", 12, null },
                    { 60, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4767), false, "Hairdrying", "سشوار", "سێشوار", 12, null },
                    { 59, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4747), false, "Cutting", "قص شعر", "قژ بڕین", 12, null },
                    { 58, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4745), false, "Hair root dye", "صبغ اطراف الشعر", "ڕەنگ کردنی ڕیشەی قژ", 12, null },
                    { 57, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4744), false, "Hair Styling", "تسريحة شعر", "ڕازاندنەوەی قژ", 12, null },
                    { 67, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4798), false, "Gel", "جلّ الأظافر", "جێل", 14, null },
                    { 56, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4742), false, "Dye", "صبغ", "ڕەنگ کردن", 12, null },
                    { 54, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4739), false, "Hair transplant", "زرع الشعر", "چاندنی پرچ", 12, null },
                    { 53, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4737), false, "Hair falling treatment", "علاج تساقط الشعر", "چارەسەری قژ وەرین", 12, null },
                    { 52, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4736), false, "Mask", "ماسك", "ماسک", 12, null },
                    { 51, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4734), false, "Keratin", "كرياتين", "کیراتین", 12, null },
                    { 50, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4724), false, "Brides' makeup", "مكياج عروس", "مکیاجی بووک", 11, null },
                    { 49, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4723), false, "Simple makeup", "مكياج ناعم", "Simple makeup", 11, null },
                    { 48, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4721), false, "Full makeup", "مكياج سهرة/ ثقيل", "Full makeup", 11, null },
                    { 47, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4711), false, "Eyebrow Extention", "إكستنشن الرموش ", "Eyebrow Extention", 10, null },
                    { 46, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4709), false, "Eyebrow tatoo", "تاتو الحواجب", "Eyebrow tatoo ", 10, null },
                    { 45, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4708), false, "Eyebrow lifting", "رفع الحاجب", "Eyebrow lifting", 10, null },
                    { 55, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4741), false, "Hair extension", "إكستنشن الشعر", "ئیکستێنشن", 12, null },
                    { 68, new DateTime(2020, 8, 8, 15, 12, 29, 722, DateTimeKind.Local).AddTicks(4800), false, "Acrylic", "آكريليك", "ئاکریلیک", 14, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 14);

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
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2617), "Thread face lifting" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2619), "Eyebrow lifting" });

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
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2630), "Eyebrow tatoo " });

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
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2659), "Eyebrow Extention" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2684), "Full makeup" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2686), "Simple makeup" });

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
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2711), "Keratin" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2713), "Mask" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2715), "Hair falling treatment" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2716), "Hair transplant" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2718), "Hair extension" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2720), "Dye" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2721), "Hair Styling" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2723), "Hair root dye" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2725), "Cutting" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2726), "سشوار" });

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
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2729), "اونبرة" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2742), "Full body" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2743), "Face" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2755), "Manicure" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2756), "Pedicure" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2758), "Gel" });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "Name_Ku" },
                values: new object[] { new DateTime(2020, 8, 4, 14, 17, 57, 359, DateTimeKind.Local).AddTicks(2760), "Acrylic" });

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
    }
}
