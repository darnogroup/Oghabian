using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class showcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Show",
                schema: "BF",
                table: "CommentFood",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Show",
                schema: "BF",
                table: "CommentArticle",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Show",
                schema: "BF",
                table: "CommentFood");

            migrationBuilder.DropColumn(
                name: "Show",
                schema: "BF",
                table: "CommentArticle");
        }
    }
}
