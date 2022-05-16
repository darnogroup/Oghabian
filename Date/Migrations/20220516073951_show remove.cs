using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class showremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentStar",
                schema: "BF",
                table: "CommentFood");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentStar",
                schema: "BF",
                table: "CommentFood",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
