using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Hidden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Users");

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
    }
}
