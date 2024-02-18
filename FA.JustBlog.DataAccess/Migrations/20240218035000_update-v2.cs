using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Data.Migrations
{
    public partial class updatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Anonymous",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "46f17c95-741d-4ab5-b60b-0503bc05a564", "e68f655b-3cdc-4d89-b58c-331c2a38e902" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2024, 2, 18, 10, 50, 0, 146, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2024, 2, 18, 10, 50, 0, 146, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentDate",
                value: new DateTime(2024, 2, 18, 10, 50, 0, 146, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentDate",
                value: new DateTime(2024, 2, 18, 10, 50, 0, 146, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommentDate",
                value: new DateTime(2024, 2, 18, 10, 50, 0, 146, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAtDate",
                value: new DateTime(2024, 2, 18, 10, 50, 0, 146, DateTimeKind.Local).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAtDate",
                value: new DateTime(2024, 2, 18, 10, 50, 0, 146, DateTimeKind.Local).AddTicks(7902));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Anonymous",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32e7a77e-04ae-492f-b32c-871c2f610e01", "da4c0e09-e3d2-4a78-8b2d-8993a0f2560b" });

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
    }
}
