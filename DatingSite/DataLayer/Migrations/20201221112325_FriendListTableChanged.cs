using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class FriendListTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_Friend",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_UserId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_Friend",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "Friend",
                table: "FriendRequests",
                newName: "RecieverId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FriendRequests",
                newName: "SenderId");

            migrationBuilder.AddColumn<int>(
                name: "RecieverID",
                table: "FriendRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_RecieverID",
                table: "FriendRequests",
                column: "RecieverID");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_RecieverID",
                table: "FriendRequests",
                column: "RecieverID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_SenderId",
                table: "FriendRequests",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_RecieverID",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_SenderId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_RecieverID",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "RecieverID",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "RecieverId",
                table: "FriendRequests",
                newName: "Friend");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "FriendRequests",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_Friend",
                table: "FriendRequests",
                column: "Friend");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_Friend",
                table: "FriendRequests",
                column: "Friend",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_UserId",
                table: "FriendRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
