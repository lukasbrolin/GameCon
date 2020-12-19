using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Game");
            migrationBuilder.DropTable("Genre");
            migrationBuilder.DropTable("Personality");
            migrationBuilder.DropTable("Platform");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
