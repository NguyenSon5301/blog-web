using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Data.Migrations
{
    public partial class AddAnonymousUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "Anonymous", "Anonymous", 0, 0, "32e7a77e-04ae-492f-b32c-871c2f610e01", "ApplicationUser", "Anonymous", true, false, null, "Anonymous", "Anonymous", "Anonymous", "Anonymous", null, false, "da4c0e09-e3d2-4a78-8b2d-8993a0f2560b", false, "Anonymous" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2023, 12, 9, 11, 59, 7, 786, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2023, 12, 9, 11, 59, 7, 786, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentDate",
                value: new DateTime(2023, 12, 9, 11, 59, 7, 786, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentDate",
                value: new DateTime(2023, 12, 9, 11, 59, 7, 786, DateTimeKind.Local).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommentDate",
                value: new DateTime(2023, 12, 9, 11, 59, 7, 786, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 9, 11, 59, 7, 786, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 9, 11, 59, 7, 786, DateTimeKind.Local).AddTicks(9531));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Anonymous");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentDate",
                value: new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentDate",
                value: new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommentDate",
                value: new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(3957));
        }
    }
}
