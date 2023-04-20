using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SeedDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventID", "Date", "Description", "DurationInHours", "InviteByEmail", "Location", "OtherDetails", "StartTime", "Title", "Type", "UserID" },
                values: new object[,]
                {
                    
                    { 1, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "nora@gmail.com", "Inodr", "", "10:00", "Version", "Private", 3 },
                   
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FullName", "Password" },
                values: new object[,]
                {
                    { 1, "kia@gmail.com", "Kai", "kai123!" },
                   
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentID", "Comments", "DateTime", "EventID" },
                values: new object[,]
                {
                    { 1, "Nice Event...!", new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                   
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventID",
                keyValue: 9);
        }
    }
}
