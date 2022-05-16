using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Law",
                schema: "BF",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SendPrice",
                schema: "BF",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeOne",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeOneAlt",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeOneLink",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeThree",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeThreeAlt",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeThreeLink",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeTwo",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeTwoAlt",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageHomeTwoLink",
                schema: "BF",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "BF",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Close = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "BF",
                columns: table => new
                {
                    OrderDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Food_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "BF",
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "BF",
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "BF",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_FoodId",
                schema: "BF",
                table: "OrderDetail",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                schema: "BF",
                table: "OrderDetail",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "BF");

            migrationBuilder.DropColumn(
                name: "Law",
                schema: "BF",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "SendPrice",
                schema: "BF",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ImageHomeOne",
                schema: "BF",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ImageHomeOneAlt",
                schema: "BF",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ImageHomeOneLink",
                schema: "BF",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ImageHomeThree",
                schema: "BF",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ImageHomeThreeAlt",
                schema: "BF",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ImageHomeThreeLink",
                schema: "BF",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ImageHomeTwo",
                schema: "BF",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ImageHomeTwoAlt",
                schema: "BF",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ImageHomeTwoLink",
                schema: "BF",
                table: "Ads");
        }
    }
}
