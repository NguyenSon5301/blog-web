using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Data.Migrations
{
    public partial class ExtendIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2023, 12, 7, 14, 58, 46, 267, DateTimeKind.Local).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2023, 12, 7, 14, 58, 46, 267, DateTimeKind.Local).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentDate",
                value: new DateTime(2023, 12, 7, 14, 58, 46, 267, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentDate",
                value: new DateTime(2023, 12, 7, 14, 58, 46, 267, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommentDate",
                value: new DateTime(2023, 12, 7, 14, 58, 46, 267, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 7, 14, 58, 46, 267, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 7, 14, 58, 46, 267, DateTimeKind.Local).AddTicks(3280));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentDate",
                value: new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentDate",
                value: new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommentDate",
                value: new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4098));
        }
    }
}
