using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class OrderMeDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForMe",
                schema: "BF",
                table: "Order");

            migrationBuilder.AddColumn<bool>(
                name: "Me",
                schema: "BF",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Me",
                schema: "BF",
                table: "OrderDetail");

            migrationBuilder.AddColumn<bool>(
                name: "ForMe",
                schema: "BF",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
