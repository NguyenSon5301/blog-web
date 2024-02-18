using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Data.Migrations
{
    public partial class AddUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4158), "007910fb-160a-4f0f-a002-ba15095b68ed" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4159), "007910fb-160a-4f0f-a002-ba15095b68ed" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4160), "007910fb-160a-4f0f-a002-ba15095b68ed" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4161), "007910fb-160a-4f0f-a002-ba15095b68ed" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CommentDate", "UserId" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 14, 50, 373, DateTimeKind.Local).AddTicks(4162), "007910fb-160a-4f0f-a002-ba15095b68ed" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
