using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FA.JustBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Action", "Controller", "Title" },
                values: new object[,]
                {
                    { 1, "Index", "Post", "Home" },
                    { 2, "PartialAboutCard", "Home", "About" },
                    { 3, "PartialAboutCard", "Home", "Entity Framework" },
                    { 4, "PartialAboutCard", "Home", "MVC" },
                    { 5, "PartialAboutCard", "Home", "Contact" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateAtDate", "Decription", "NumberView", "Rate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 1, 14, 43, 11, 466, DateTimeKind.Local).AddTicks(5945), "sdsdsdsdsdsdsdsd2323", 100, 4.5, "This is my first post!!!" },
                    { 2, new DateTime(2023, 12, 1, 14, 43, 11, 466, DateTimeKind.Local).AddTicks(5957), "23sdsd2323sd", 200, 4.5, "My second Post!!!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
