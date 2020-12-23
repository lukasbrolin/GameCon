using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameUser_Users_UsersId",
                table: "GameUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreUser_Users_UsersId",
                table: "GenreUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformUser_Users_UsersId",
                table: "PlatformUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_FriendsId",
                table: "UserUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_UsersId",
                table: "UserUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserUser",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "FriendsId",
                table: "UserUser",
                newName: "FriendsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUser_UsersId",
                table: "UserUser",
                newName: "IX_UserUser_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "PlatformUser",
                newName: "UsersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformUser_UsersId",
                table: "PlatformUser",
                newName: "IX_PlatformUser_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "GenreUser",
                newName: "UsersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreUser_UsersId",
                table: "GenreUser",
                newName: "IX_GenreUser_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "GameUser",
                newName: "UsersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_GameUser_UsersId",
                table: "GameUser",
                newName: "IX_GameUser_UsersUserId");

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesGameId", "GenresGenreId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 13, DateTimeKind.Local).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 14, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 14, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 15, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 15, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 15, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 15, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 15, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 38, 10, 15, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.AddForeignKey(
                name: "FK_GameUser_Users_UsersUserId",
                table: "GameUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreUser_Users_UsersUserId",
                table: "GenreUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformUser_Users_UsersUserId",
                table: "PlatformUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_FriendsUserId",
                table: "UserUser",
                column: "FriendsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_UsersUserId",
                table: "UserUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameUser_Users_UsersUserId",
                table: "GameUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreUser_Users_UsersUserId",
                table: "GenreUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformUser_Users_UsersUserId",
                table: "PlatformUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_FriendsUserId",
                table: "UserUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_UsersUserId",
                table: "UserUser");

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "UserUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "FriendsUserId",
                table: "UserUser",
                newName: "FriendsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUser_UsersUserId",
                table: "UserUser",
                newName: "IX_UserUser_UsersId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "PlatformUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformUser_UsersUserId",
                table: "PlatformUser",
                newName: "IX_PlatformUser_UsersId");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "GenreUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreUser_UsersUserId",
                table: "GenreUser",
                newName: "IX_GenreUser_UsersId");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "GameUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_GameUser_UsersUserId",
                table: "GameUser",
                newName: "IX_GameUser_UsersId");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 716, DateTimeKind.Local).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 719, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 719, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 720, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 720, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 720, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 721, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 721, DateTimeKind.Local).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 22, 5, 4, 721, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.AddForeignKey(
                name: "FK_GameUser_Users_UsersId",
                table: "GameUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreUser_Users_UsersId",
                table: "GenreUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformUser_Users_UsersId",
                table: "PlatformUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_FriendsId",
                table: "UserUser",
                column: "FriendsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_UsersId",
                table: "UserUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
