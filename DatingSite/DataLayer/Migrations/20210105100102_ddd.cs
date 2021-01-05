using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Friends",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 685, DateTimeKind.Local).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 687, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 687, DateTimeKind.Local).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 688, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 688, DateTimeKind.Local).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 688, DateTimeKind.Local).AddTicks(2970));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 688, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 688, DateTimeKind.Local).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 5, 11, 1, 1, 688, DateTimeKind.Local).AddTicks(5485));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
