using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class Orderremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "BF",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                schema: "BF",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
