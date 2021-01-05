using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class defaultvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Friends",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Default");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 4, "Noobs" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 185, DateTimeKind.Local).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 187, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 187, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 187, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 187, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 187, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 188, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 188, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 10, 10, 28, 188, DateTimeKind.Local).AddTicks(2056));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Friends",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Noobs");

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
