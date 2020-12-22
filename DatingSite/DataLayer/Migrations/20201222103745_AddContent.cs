using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Noobs" },
                    { 2, "Pros" },
                    { 3, "Omegaluls" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Publisher" },
                values: new object[,]
                {
                    { 1, "Dota 2", "Valve" },
                    { 2, "CS:GO", "Valve" },
                    { 3, "PUBG", "Bluehole Corporation" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "MOBA" },
                    { 2, "FPS" },
                    { 3, "FPS" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Norwegian" },
                    { 3, "South African" },
                    { 1, "Swedish" }
                });

            migrationBuilder.InsertData(
                table: "Personalities",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Cute" },
                    { 2, "Narcissistic" },
                    { 3, "Manipulative" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "XBOX" },
                    { 2, "PS1" },
                    { 3, "PS3" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Blocked" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Age", "FirstName", "Gender", "LastName", "Mail", "NationalityId", "Online", "PersonalityId", "PreferedLanguage" },
                values: new object[,]
                {
                    { 2, true, 27, "Lukas", "Male", "Brolin", "lukas.broling@dating.com", null, false, null, "Swedish" },
                    { 1, true, 28, "Simon", "Male", "Bernsdorff Wallstedt", "simon.bernsdorff-wallstedt@dating.com", null, false, null, "Swedish" },
                    { 3, true, 27, "Filip", "Male", "Johansson", "filip.johansson@dating.com", null, false, null, "Swedish" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "RecieverId", "SenderId", "Text", "TimeStamp" },
                values: new object[,]
                {
                    { 1, 1, 2, "Hello muthafucka", new DateTime(2020, 12, 22, 11, 37, 44, 926, DateTimeKind.Local).AddTicks(1662) },
                    { 3, 2, 1, "SKKRTSKRRRT", new DateTime(2020, 12, 22, 11, 37, 44, 930, DateTimeKind.Local).AddTicks(2797) },
                    { 2, 3, 1, "Check this shit out", new DateTime(2020, 12, 22, 11, 37, 44, 930, DateTimeKind.Local).AddTicks(2759) }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "RecieverId", "SenderId", "Text", "TimeStamp" },
                values: new object[,]
                {
                    { 1, 1, 2, "Holy shit dude.", new DateTime(2020, 12, 22, 11, 37, 44, 932, DateTimeKind.Local).AddTicks(508) },
                    { 2, 2, 3, "Holy shit dude.", new DateTime(2020, 12, 22, 11, 37, 44, 932, DateTimeKind.Local).AddTicks(1471) },
                    { 3, 3, 1, "Holy shit dude.", new DateTime(2020, 12, 22, 11, 37, 44, 932, DateTimeKind.Local).AddTicks(1507) }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "UserID", "Visitor", "TimeStamp" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 12, 22, 11, 37, 44, 932, DateTimeKind.Local).AddTicks(5669) },
                    { 2, 3, new DateTime(2020, 12, 22, 11, 37, 44, 932, DateTimeKind.Local).AddTicks(6553) },
                    { 3, 2, new DateTime(2020, 12, 22, 11, 37, 44, 932, DateTimeKind.Local).AddTicks(6565) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personalities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personalities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personalities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumns: new[] { "UserID", "Visitor" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumns: new[] { "UserID", "Visitor" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumns: new[] { "UserID", "Visitor" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
