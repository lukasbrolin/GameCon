using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GamePlatform",
                columns: new[] { "GamesGameId", "PlatformsPlatformId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "GameUser",
                columns: new[] { "GamesGameId", "UsersUserId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "GenreUser",
                columns: new[] { "GenresGenreId", "UsersUserId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 180, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 181, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 181, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.InsertData(
                table: "PlatformUser",
                columns: new[] { "PlatformsPlatformId", "UsersUserId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 182, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 182, DateTimeKind.Local).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 182, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 182, DateTimeKind.Local).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 182, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 22, 23, 50, 44, 182, DateTimeKind.Local).AddTicks(7124));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesGameId", "PlatformsPlatformId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GameUser",
                keyColumns: new[] { "GamesGameId", "UsersUserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GenreUser",
                keyColumns: new[] { "GenresGenreId", "UsersUserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PlatformUser",
                keyColumns: new[] { "PlatformsPlatformId", "UsersUserId" },
                keyValues: new object[] { 2, 3 });

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
        }
    }
}
