using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class DiscountOrderBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "BF",
                table: "OrderDetail");

            migrationBuilder.AddColumn<bool>(
                name: "Discount",
                schema: "BF",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "BF",
                table: "Order");

            migrationBuilder.AddColumn<bool>(
                name: "Discount",
                schema: "BF",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
