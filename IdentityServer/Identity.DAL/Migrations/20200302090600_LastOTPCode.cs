using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.DAL.Migrations
{
    public partial class LastOTPCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastOTPCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOTPTime",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastOTPCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastOTPTime",
                table: "AspNetUsers");
        }
    }
}
