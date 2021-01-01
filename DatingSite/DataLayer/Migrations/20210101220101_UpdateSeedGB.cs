using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class UpdateSeedGB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 277, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 279, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 279, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 5,
                column: "Name",
                value: "Great Britain");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 280, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 280, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 280, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 280, DateTimeKind.Local).AddTicks(2959));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 280, DateTimeKind.Local).AddTicks(3611));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 23, 1, 1, 280, DateTimeKind.Local).AddTicks(3622));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 918, DateTimeKind.Local).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 920, DateTimeKind.Local).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 920, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 5,
                column: "Name",
                value: "England");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 921, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 921, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 921, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 921, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 921, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 52, 56, 921, DateTimeKind.Local).AddTicks(5896));
        }
    }
}
