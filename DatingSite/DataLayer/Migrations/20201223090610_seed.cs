using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "FriendId", "CategoryId", "ReceiverId", "SenderId", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, 2, 1, 1 },
                    { 2, 2, 3, 2, 2 },
                    { 3, 1, 1, 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 785, DateTimeKind.Local).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 788, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 788, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 790, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 790, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 790, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 790, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 790, DateTimeKind.Local).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 6, 9, 790, DateTimeKind.Local).AddTicks(5965));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "FriendId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "FriendId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "FriendId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 723, DateTimeKind.Local).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 727, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 727, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 728, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 728, DateTimeKind.Local).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 728, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 729, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 729, DateTimeKind.Local).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2020, 12, 23, 10, 0, 5, 729, DateTimeKind.Local).AddTicks(5028));
        }
    }
}
