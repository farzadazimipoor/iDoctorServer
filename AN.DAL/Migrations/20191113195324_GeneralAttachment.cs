using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class GeneralAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentAttachments",
                schema: "an");

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ThumbnailUrl = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Size = table.Column<double>(nullable: false),
                    DeleteUrl = table.Column<string>(nullable: false),
                    FileType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Owner = table.Column<int>(nullable: false),
                    OwnerTableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(3089));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(3161));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 67, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 67, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 67, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 62, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 62, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 62, DateTimeKind.Local).AddTicks(4321));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2556));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2563));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 66, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(7590));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 13, 22, 53, 22, 65, DateTimeKind.Local).AddTicks(7657));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "an");

            migrationBuilder.CreateTable(
                name: "TreatmentAttachments",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeleteUrl = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Size = table.Column<double>(nullable: false),
                    ThumbnailUrl = table.Column<string>(nullable: false),
                    TreatmentHistoryId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentAttachments_TreatmentHistory_TreatmentHistoryId",
                        column: x => x.TreatmentHistoryId,
                        principalSchema: "an",
                        principalTable: "TreatmentHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 956, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 956, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 956, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 959, DateTimeKind.Local).AddTicks(4788));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 959, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 958, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 958, DateTimeKind.Local).AddTicks(9649));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 952, DateTimeKind.Local).AddTicks(3203));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 952, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 952, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 958, DateTimeKind.Local).AddTicks(3582));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 958, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7526));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7590));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7646));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7690));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(714));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(798));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(803));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(812));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 37, 22, 957, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentAttachments_TreatmentHistoryId",
                schema: "an",
                table: "TreatmentAttachments",
                column: "TreatmentHistoryId");
        }
    }
}
