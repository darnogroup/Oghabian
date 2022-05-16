using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class RATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FoodPrice",
                schema: "BF",
                table: "Food",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FoodDiscountPrice",
                schema: "BF",
                table: "Food",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                schema: "BF",
                table: "Food",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                schema: "BF",
                table: "Food");

            migrationBuilder.AlterColumn<string>(
                name: "FoodPrice",
                schema: "BF",
                table: "Food",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FoodDiscountPrice",
                schema: "BF",
                table: "Food",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
