using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class isMedical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MedicalRecords",
                schema: "BF",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalRecords",
                schema: "BF",
                table: "AspNetUsers");
        }
    }
}
