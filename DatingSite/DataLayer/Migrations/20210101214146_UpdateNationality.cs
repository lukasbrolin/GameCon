using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class UpdateNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 880, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 882, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 882, DateTimeKind.Local).AddTicks(732));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 1,
                column: "Name",
                value: "Sweden");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 2,
                column: "Name",
                value: "Norway");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 3,
                column: "Name",
                value: "Denmark");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 4,
                column: "Name",
                value: "Germany");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 5,
                column: "Name",
                value: "England");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 6,
                column: "Name",
                value: "Spain");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 7,
                column: "Name",
                value: "France");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 8,
                column: "Name",
                value: "USA");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 882, DateTimeKind.Local).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 882, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 882, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 883, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 883, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2021, 1, 1, 22, 41, 45, 883, DateTimeKind.Local).AddTicks(1880));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 740, DateTimeKind.Local).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 742, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 742, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 1,
                column: "Name",
                value: "Swedish");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 2,
                column: "Name",
                value: "Norwegian");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 3,
                column: "Name",
                value: "Danish");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 4,
                column: "Name",
                value: "German");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 5,
                column: "Name",
                value: "English");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 6,
                column: "Name",
                value: "Spanish");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 7,
                column: "Name",
                value: "French");

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "NationalityId",
                keyValue: 8,
                column: "Name",
                value: "American");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 743, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 743, DateTimeKind.Local).AddTicks(1921));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 743, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 743, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 743, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 30, 16, 34, 17, 743, DateTimeKind.Local).AddTicks(4785));
        }
    }
}
