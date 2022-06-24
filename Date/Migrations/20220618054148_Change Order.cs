using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class ChangeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForMe",
                schema: "BF",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentOnTheSpot",
                schema: "BF",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForMe",
                schema: "BF",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentOnTheSpot",
                schema: "BF",
                table: "Order");
        }
    }
}
