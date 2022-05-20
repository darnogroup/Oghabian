using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class userquestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserQuestion",
                schema: "BF",
                columns: table => new
                {
                    UserQuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserQuestionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserQuestionBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestion", x => x.UserQuestionId);
                    table.ForeignKey(
                        name: "FK_UserQuestion_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswer",
                schema: "BF",
                columns: table => new
                {
                    UserAnswerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserAnswerBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswer", x => x.UserAnswerId);
                    table.ForeignKey(
                        name: "FK_UserAnswer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserAnswer_UserQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "BF",
                        principalTable: "UserQuestion",
                        principalColumn: "UserQuestionId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_QuestionId",
                schema: "BF",
                table: "UserAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserId",
                schema: "BF",
                table: "UserAnswer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestion_UserId",
                schema: "BF",
                table: "UserQuestion",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswer",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "UserQuestion",
                schema: "BF");
        }
    }
}
