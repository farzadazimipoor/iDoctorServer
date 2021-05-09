using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.DAL.Migrations
{
    public partial class identityUserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagedCenters",
                table: "AspNetUserRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagedCenters",
                table: "AspNetUserRoles");
        }
    }
}
