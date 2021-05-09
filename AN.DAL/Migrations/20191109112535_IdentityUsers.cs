using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.DAL.Migrations
{
    public partial class IdentityUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonUserProfile",
                schema: "an");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                schema: "an",
                table: "Person");

            migrationBuilder.AddColumn<bool>(
                name: "MobileConfirmed",
                schema: "an",
                table: "Person",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "an",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                schema: "an",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(maxLength: 256, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUser_Person_PersonId",
                        column: x => x.PersonId,
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
                value: new DateTime(2019, 11, 9, 14, 25, 33, 124, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 124, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 124, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 126, DateTimeKind.Local).AddTicks(8436));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 126, DateTimeKind.Local).AddTicks(8481));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 126, DateTimeKind.Local).AddTicks(2005));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 126, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 121, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 121, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 121, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 126, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 126, DateTimeKind.Local).AddTicks(335));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6141));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6149));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6162));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6169));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6322));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6365));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6369));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6375));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6405));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6408));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6433));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(6464));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(1538));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(1552));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 9, 14, 25, 33, 125, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.CreateIndex(
                name: "IX_Person_ParentId",
                schema: "an",
                table: "Person",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_PersonId",
                schema: "an",
                table: "IdentityUser",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_ParentId",
                schema: "an",
                table: "Person",
                column: "ParentId",
                principalSchema: "an",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_ParentId",
                schema: "an",
                table: "Person");

            migrationBuilder.DropTable(
                name: "IdentityUser",
                schema: "an");

            migrationBuilder.DropIndex(
                name: "IX_Person_ParentId",
                schema: "an",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MobileConfirmed",
                schema: "an",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "an",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                schema: "an",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonUserProfile",
                schema: "an",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: false),
                    IdentityUserName = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonUserProfile", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_PersonUserProfile_Person_PersonId",
                        column: x => x.PersonId,
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
                value: new DateTime(2019, 11, 8, 20, 8, 12, 69, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 69, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "City",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 69, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Expertise",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(2737));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ExpertiseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 66, DateTimeKind.Local).AddTicks(8627));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 66, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Province",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 66, DateTimeKind.Local).AddTicks(9857));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ScientificCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 71, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7039));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7042));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7196));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "Service",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                schema: "an",
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 8, 20, 8, 12, 70, DateTimeKind.Local).AddTicks(2698));
        }
    }
}
