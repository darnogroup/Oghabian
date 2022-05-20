using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class decriptiontag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "BF",
                table: "Seo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "BF",
                table: "Seo");
        }
    }
}
