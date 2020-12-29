using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 12, 47, 10, 532, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 12, 47, 10, 533, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 12, 47, 10, 533, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.InsertData(
                table: "Personalities",
                columns: new[] { "PersonalityId", "Description" },
                values: new object[] { 4, "Strategist" });

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
                value: new DateTime(2020, 12, 28, 12, 47, 10, 534, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 12, 47, 10, 534, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 12, 47, 10, 534, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 12, 47, 10, 534, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 12, 47, 10, 535, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 28, 12, 47, 10, 535, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "Age", "FirstName", "Gender", "ImgUrl", "LastName", "Mail", "NationalityId", "Online", "PersonalityId", "PreferedLanguage" },
                values: new object[] { 4, true, 22, "Magnus", "Male", "Images/User/User.jpg", "Karlsson", "magnus.karlsson@dating.com", 1, false, 4, "English" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personalities",
                keyColumn: "PersonalityId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 563, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 565, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 565, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 566, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 566, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 566, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 566, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 566, DateTimeKind.Local).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 17, 57, 566, DateTimeKind.Local).AddTicks(6090));
        }
    }
}
