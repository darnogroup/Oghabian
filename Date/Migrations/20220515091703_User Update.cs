using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCalories",
                schema: "BF",
                table: "MedicalInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCarbohydrate",
                schema: "BF",
                table: "MedicalInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFat",
                schema: "BF",
                table: "MedicalInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProtein",
                schema: "BF",
                table: "MedicalInformation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCalories",
                schema: "BF",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "UserCarbohydrate",
                schema: "BF",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "UserFat",
                schema: "BF",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "UserProtein",
                schema: "BF",
                table: "MedicalInformation");
        }
    }
}
