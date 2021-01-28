using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBlog.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "Post", "PostedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Joe Bloggs", "Lorem ipsum dolor sit amet...", new DateTimeOffset(new DateTime(2020, 12, 29, 10, 48, 6, 887, DateTimeKind.Unspecified).AddTicks(6961), new TimeSpan(0, 7, 0, 0, 0)), "If only C# worked in the browser" },
                    { 2, "Joe Bloggs", "Lorem ipsum dolor sit amet...", new DateTimeOffset(new DateTime(2021, 1, 3, 10, 48, 6, 891, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 7, 0, 0, 0)), "400th JS Framework released" },
                    { 3, "Joe Bloggs", "Lorem ipsum dolor sit amet...", new DateTimeOffset(new DateTime(2021, 1, 8, 10, 48, 6, 891, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 7, 0, 0, 0)), "WebAssembly FTW" },
                    { 4, "Joe Bloggs", "Lorem ipsum dolor sit amet...", new DateTimeOffset(new DateTime(2021, 1, 13, 10, 48, 6, 891, DateTimeKind.Unspecified).AddTicks(6512), new TimeSpan(0, 7, 0, 0, 0)), "Blazor is Awesome!" },
                    { 5, "Joe Bloggs", "Lorem ipsum dolor sit amet...", new DateTimeOffset(new DateTime(2021, 1, 18, 10, 48, 6, 891, DateTimeKind.Unspecified).AddTicks(6516), new TimeSpan(0, 7, 0, 0, 0)), "Your first Blazor App" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");
        }
    }
}
