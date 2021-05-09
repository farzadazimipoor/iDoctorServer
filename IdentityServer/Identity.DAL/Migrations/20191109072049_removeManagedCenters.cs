using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.DAL.Migrations
{
    public partial class removeManagedCenters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagedCenters",
                table: "AspNetUserRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagedCenters",
                table: "AspNetUserRoles",
                nullable: true);
        }
    }
}
