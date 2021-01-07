using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class newSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 873, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 875, DateTimeKind.Local).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 875, DateTimeKind.Local).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 876, DateTimeKind.Local).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 876, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 876, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "ImgUrl",
                value: "~/img/avatars/csgo1.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "ImgUrl",
                value: "~/img/avatars/csgo2.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "ImgUrl",
                value: "~/img/avatars/csgo3.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "ImgUrl",
                value: "~/img/avatars/csgo4.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "ImgUrl",
                value: "~/img/avatars/dota1.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "ImgUrl",
                value: "~/img/avatars/dota2.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "ImgUrl",
                value: "~/img/avatars/pubg.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "ImgUrl",
                value: "~/img/avatars/wow1.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "ImgUrl",
                value: "~/img/avatars/wow2.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "ImgUrl",
                value: "~/img/avatars/wow3.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "ImgUrl",
                value: "~/img/avatars/wow.6.jpg");

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 876, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 876, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 7, 15, 53, 24, 876, DateTimeKind.Local).AddTicks(7386));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 171, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 173, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 173, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 173, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 173, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 173, DateTimeKind.Local).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "ImgUrl",
                value: "~/img/avatars/avatar1.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "ImgUrl",
                value: "~/img/avatars/avatar2.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "ImgUrl",
                value: "~/img/avatars/avatar3.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "ImgUrl",
                value: "~/img/avatars/avatar4.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "ImgUrl",
                value: "~/img/avatars/avatar5.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "ImgUrl",
                value: "~/img/avatars/avatar2.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "ImgUrl",
                value: "~/img/avatars/avatar3.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "ImgUrl",
                value: "~/img/avatars/avatar4.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "ImgUrl",
                value: "~/img/avatars/avatar5.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "ImgUrl",
                value: "~/img/avatars/avatar2.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "ImgUrl",
                value: "~/img/avatars/avatar1.png");

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 174, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 174, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 6, 16, 4, 44, 174, DateTimeKind.Local).AddTicks(2541));
        }
    }
}
