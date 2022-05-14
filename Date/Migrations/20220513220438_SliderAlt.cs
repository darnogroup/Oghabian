using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class SliderAlt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SliderAlt",
                schema: "BF",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderAlt",
                schema: "BF",
                table: "Slider");
        }
    }
}
