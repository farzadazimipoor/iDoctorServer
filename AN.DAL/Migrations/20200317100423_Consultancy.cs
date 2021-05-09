using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class Consultancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultancy",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultancy_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultancy_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsultancyMessage",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Content = table.Column<string>(maxLength: 2048, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsultancyId = table.Column<int>(nullable: false),
                    ServiceSupplyId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultancyMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultancyMessage_Consultancy_ConsultancyId",
                        column: x => x.ConsultancyId,
                        principalSchema: "an",
                        principalTable: "Consultancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultancyMessage_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "an",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultancyMessage_ServiceSupply_ServiceSupplyId",
                        column: x => x.ServiceSupplyId,
                        principalSchema: "an",
                        principalTable: "ServiceSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Drug",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 333, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 332, DateTimeKind.Local).AddTicks(3465));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 332, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 328, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 328, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 328, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(5244));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 332, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 332, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3513));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3529));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3547));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3580));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3660));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3671));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3673));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3681));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3709));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3715));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 331, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 17, 13, 4, 21, 330, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.CreateIndex(
                name: "IX_Consultancy_PersonId",
                schema: "an",
                table: "Consultancy",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultancy_ServiceSupplyId",
                schema: "an",
                table: "Consultancy",
                column: "ServiceSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultancyMessage_ConsultancyId",
                schema: "an",
                table: "ConsultancyMessage",
                column: "ConsultancyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultancyMessage_PersonId",
                schema: "an",
                table: "ConsultancyMessage",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultancyMessage_ServiceSupplyId",
                schema: "an",
                table: "ConsultancyMessage",
                column: "ServiceSupplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultancyMessage",
                schema: "an");

            migrationBuilder.DropTable(
                name: "Consultancy",
                schema: "an");

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
        }
    }
}
