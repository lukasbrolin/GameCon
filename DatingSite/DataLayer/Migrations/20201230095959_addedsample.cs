using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class addedsample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesGameId", "GenresGenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name", "Publisher" },
                values: new object[,]
                {
                    { 4, "World of Warcraft", "Blizzard" },
                    { 5, "Among us", "InnerSloth" }
                });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "Name",
                value: "Explore");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 4, "King of the hill" },
                    { 5, "MMO" },
                    { 6, "Strategy" },
                    { 7, "Open world" }
                });

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

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 3,
                column: "Name",
                value: "Danish");

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "Name" },
                values: new object[,]
                {
                    { 4, "German" },
                    { 5, "English" },
                    { 8, "American" },
                    { 7, "French" },
                    { 6, "Spanish" }
                });

            migrationBuilder.UpdateData(
                table: "Personalities",
                keyColumn: "PersonalityId",
                keyValue: 4,
                column: "Description",
                value: "Shy");

            migrationBuilder.InsertData(
                table: "Personalities",
                columns: new[] { "PersonalityId", "Description" },
                values: new object[,]
                {
                    { 6, "Strategist" },
                    { 5, "Leader" }
                });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 2,
                column: "Name",
                value: "PS");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 3,
                column: "Name",
                value: "PC");

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
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "Age", "LastName", "Mail" },
                values: new object[] { 34, "Fredriksson", "magnus.fredriksson@dating.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "Age", "FirstName", "Gender", "ImgUrl", "LastName", "Mail", "NationalityId", "Online", "PersonalityId", "PreferedLanguage" },
                values: new object[,]
                {
                    { 5, true, 22, "Didrik", "Male", "Images/User/User.jpg", "Hjelm", "didrik.hjelm@dating.com", 2, false, 2, "Norwegian" },
                    { 7, true, 27, "Kassandra", "Female", "Images/User/User.jpg", "Lökholm", "kassandra.Lökholm@dating.com", 1, false, 1, "Swedish" }
                });

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

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesGameId", "GenresGenreId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 4, 7 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "Age", "FirstName", "Gender", "ImgUrl", "LastName", "Mail", "NationalityId", "Online", "PersonalityId", "PreferedLanguage" },
                values: new object[,]
                {
                    { 9, true, 41, "Sebastian", "Male", "Images/User/User.jpg", "Vettel", "sebastian.vettel@dating.com", 4, false, 3, "German" },
                    { 10, true, 38, "Nico", "Male", "Images/User/User.jpg", "Rosberg", "nico.rosberg@dating.com", 4, false, 3, "German" },
                    { 11, true, 30, "Emma", "Female", "Images/User/User.jpg", "Watson", "emma.watson@dating.com", 5, false, 4, "English" },
                    { 6, true, 25, "Selma", "Female", "Images/User/User.jpg", "Nordheim", "selma.nordheim@dating.com", 2, false, 5, "Norwegian" },
                    { 8, true, 31, "Kent", "Male", "Images/User/User.jpg", "Andersson", "kent.andersson@dating.com", 1, false, 5, "Swedish" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesGameId", "GenresGenreId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Personalities",
                keyColumn: "PersonalityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personalities",
                keyColumn: "PersonalityId",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesGameId", "GenresGenreId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "Name",
                value: "FPS");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 569, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 571, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 571, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 3,
                column: "Name",
                value: "South African");

            migrationBuilder.UpdateData(
                table: "Personalities",
                keyColumn: "PersonalityId",
                keyValue: 4,
                column: "Description",
                value: "Strategist");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 2,
                column: "Name",
                value: "PS1");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 3,
                column: "Name",
                value: "PS3");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "Name" },
                values: new object[,]
                {
                    { 4, "PC" },
                    { 5, "PS5" }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 572, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 572, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 572, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "Age", "LastName", "Mail" },
                values: new object[] { 22, "Karlsson", "magnus.karlsson@dating.com" });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 572, DateTimeKind.Local).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 572, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 16, 52, 43, 572, DateTimeKind.Local).AddTicks(6335));
        }
    }
}
