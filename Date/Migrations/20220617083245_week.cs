using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class week : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Day",
                schema: "BF",
                table: "Food",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                schema: "BF",
                table: "Food");
        }
    }
}
