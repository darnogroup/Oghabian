using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class accep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accept",
                schema: "BF",
                table: "UserQuestion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accept",
                schema: "BF",
                table: "UserQuestion");
        }
    }
}
