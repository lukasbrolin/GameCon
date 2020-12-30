using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class addedsample2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesGameId", "GenresGenreId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 2, 2 },
                    { 2, 6 },
                    { 3, 2 },
                    { 3, 6 },
                    { 3, 7 },
                    { 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "GamePlatform",
                columns: new[] { "GamesGameId", "PlatformsPlatformId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 3, 3 },
                    { 5, 3 },
                    { 2, 2 },
                    { 2, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "GameUser",
                columns: new[] { "GamesGameId", "UsersUserId" },
                values: new object[,]
                {
                    { 5, 5 },
                    { 4, 11 },
                    { 2, 11 },
                    { 2, 10 },
                    { 1, 9 },
                    { 5, 8 },
                    { 4, 8 },
                    { 1, 8 },
                    { 4, 7 },
                    { 4, 6 },
                    { 3, 6 },
                    { 2, 6 },
                    { 4, 5 },
                    { 1, 5 },
                    { 5, 4 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 4, 4 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "GenreUser",
                columns: new[] { "GenresGenreId", "UsersUserId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "GenreUser",
                columns: new[] { "GenresGenreId", "UsersUserId" },
                values: new object[,]
                {
                    { 6, 6 },
                    { 2, 7 },
                    { 3, 8 },
                    { 4, 10 },
                    { 3, 10 },
                    { 4, 11 },
                    { 5, 11 },
                    { 7, 11 },
                    { 3, 5 },
                    { 4, 9 },
                    { 2, 5 },
                    { 2, 2 },
                    { 7, 4 },
                    { 1, 5 },
                    { 1, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 1, 2 },
                    { 2, 1 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 1, 4 },
                    { 4, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 577, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 578, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 578, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.InsertData(
                table: "PlatformUser",
                columns: new[] { "PlatformsPlatformId", "UsersUserId" },
                values: new object[,]
                {
                    { 3, 8 },
                    { 3, 11 },
                    { 2, 10 },
                    { 3, 10 },
                    { 3, 9 },
                    { 3, 7 },
                    { 3, 4 },
                    { 1, 5 },
                    { 3, 5 },
                    { 1, 4 },
                    { 1, 3 },
                    { 3, 3 },
                    { 3, 2 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "PlatformUser",
                columns: new[] { "PlatformsPlatformId", "UsersUserId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 579, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 579, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 579, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 579, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 579, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 11, 21, 5, 579, DateTimeKind.Local).AddTicks(5619));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesGameId", "PlatformsPlatformId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesGameId", "PlatformsPlatformId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesGameId", "PlatformsPlatformId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesGameId", "PlatformsPlatformId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesGameId", "PlatformsPlatformId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesGameId", "PlatformsPlatformId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesGameId", "GenresGenreId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "GenreUser",
                columns: new[] { "GenresGenreId", "UsersUserId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 21, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 23, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 23, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.InsertData(
                table: "PlatformUser",
                columns: new[] { "PlatformsPlatformId", "UsersUserId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 23, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 23, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 23, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 23, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 23, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 10, 59, 59, 23, DateTimeKind.Local).AddTicks(9385));
        }
    }
}
