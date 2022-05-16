using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodCode",
                schema: "BF",
                table: "Food",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodCode",
                schema: "BF",
                table: "Food");
        }
    }
}
