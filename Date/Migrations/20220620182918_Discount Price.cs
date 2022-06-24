using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class DiscountPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DiscountPrice",
                schema: "BF",
                table: "Discount",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                schema: "BF",
                table: "Discount");
        }
    }
}
