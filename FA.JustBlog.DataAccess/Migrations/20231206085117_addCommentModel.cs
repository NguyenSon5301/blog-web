using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FA.JustBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCommentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentDate", "CommentDescription", "PostId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4285), "Bai viet hay 1", 1 },
                    { 2, new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4287), "Bai viet hay 2", 1 },
                    { 3, new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4288), "Bai viet hay 3", 1 },
                    { 4, new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4289), "Bai viet hay 4", 2 },
                    { 5, new DateTime(2023, 12, 6, 15, 51, 16, 760, DateTimeKind.Local).AddTicks(4290), "Bai viet hay 5", 2 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 3, 14, 36, 54, 413, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAtDate",
                value: new DateTime(2023, 12, 3, 14, 36, 54, 413, DateTimeKind.Local).AddTicks(868));
        }
    }
}
