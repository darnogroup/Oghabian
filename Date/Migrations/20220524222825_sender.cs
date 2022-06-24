using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class sender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sender",
                schema: "BF",
                table: "ChatMessage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sender",
                schema: "BF",
                table: "ChatMessage");
        }
    }
}
