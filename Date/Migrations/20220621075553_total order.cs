using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class totalorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total",
                schema: "BF",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                schema: "BF",
                table: "Order");
        }
    }
}
