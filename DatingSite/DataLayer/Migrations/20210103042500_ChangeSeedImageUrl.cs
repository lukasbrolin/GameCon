using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ChangeSeedImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 3, 5, 25, 0, 248, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 3, 5, 25, 0, 249, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 3, 5, 25, 0, 249, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 3, 5, 25, 0, 250, DateTimeKind.Local).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 3, 5, 25, 0, 250, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 3, 5, 25, 0, 250, DateTimeKind.Local).AddTicks(7710));

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
                value: new DateTime(2021, 1, 3, 5, 25, 0, 251, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 3, 5, 25, 0, 251, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 3, 5, 25, 0, 251, DateTimeKind.Local).AddTicks(667));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 612, DateTimeKind.Local).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 614, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 614, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 614, DateTimeKind.Local).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 614, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 614, DateTimeKind.Local).AddTicks(9853));

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
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "ImgUrl",
                value: "Images/User/User.jpg");

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 615, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 615, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 2, 20, 6, 2, 615, DateTimeKind.Local).AddTicks(2354));
        }
    }
}
