using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class Ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                schema: "BF",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TicketDetail",
                schema: "BF",
                columns: table => new
                {
                    TicketDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetail", x => x.TicketDetailId);
                    table.ForeignKey(
                        name: "FK_TicketDetail_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TicketDetail_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "BF",
                        principalTable: "Ticket",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                schema: "BF",
                table: "Ticket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetail_TicketId",
                schema: "BF",
                table: "TicketDetail",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetail_UserId",
                schema: "BF",
                table: "TicketDetail",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketDetail",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Ticket",
                schema: "BF");
        }
    }
}
