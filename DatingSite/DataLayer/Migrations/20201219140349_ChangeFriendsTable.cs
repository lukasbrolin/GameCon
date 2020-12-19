using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ChangeFriendsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Friends");
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Friend1 = table.Column<int>(type: "int", nullable: false),
                    Friend2 = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.Friend1, x.Friend2 });
                    table.ForeignKey(
                            name: "FK_Friends_Users_Friend1ID",
                            column: x => x.Friend1,
                            principalTable: "Users",
                            principalColumn: "Id")
                        ;
                    table.ForeignKey(
                            name: "FK_Friends_Users_Friend2ID",
                            column: x => x.Friend2,
                            principalTable: "Users",
                            principalColumn: "Id")
                        ;
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
