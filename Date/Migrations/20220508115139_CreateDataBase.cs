﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BF");

            migrationBuilder.CreateTable(
                name: "Ads",
                schema: "BF",
                columns: table => new
                {
                    AdsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageOneAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageOneLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTwoAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTwoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageSidebar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageSidebarAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageSidebarLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.AdsId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "BF",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "BF",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "BF",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                schema: "BF",
                columns: table => new
                {
                    MealId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MealTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.MealId);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "BF",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Seo",
                schema: "BF",
                columns: table => new
                {
                    SeoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraphTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphSiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Footer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seo", x => x.SeoId);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                schema: "BF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkdin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceBook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiSms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sickness",
                schema: "BF",
                columns: table => new
                {
                    SicknessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SicknessTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SicknessImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sickness", x => x.SicknessId);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                schema: "BF",
                columns: table => new
                {
                    SliderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SliderImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.SliderId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "BF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "BF",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "BF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "BF",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "BF",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "BF",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "BF",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "BF",
                columns: table => new
                {
                    ArticleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArticleTitle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArticleImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitCount = table.Column<int>(type: "int", nullable: false),
                    ArticleBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Article_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "BF",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                schema: "BF",
                columns: table => new
                {
                    FoodId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodDiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodCalories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodCarbohydrate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodFat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodProtein = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SicknessId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Food_Meal_MealId",
                        column: x => x.MealId,
                        principalSchema: "BF",
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Food_Sickness_SicknessId",
                        column: x => x.SicknessId,
                        principalSchema: "BF",
                        principalTable: "Sickness",
                        principalColumn: "SicknessId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CommentArticle",
                schema: "BF",
                columns: table => new
                {
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentArticle", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentArticle_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "BF",
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CommentFood",
                schema: "BF",
                columns: table => new
                {
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentStar = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentFood", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentFood_Food_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "BF",
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteEntity",
                schema: "BF",
                columns: table => new
                {
                    FavoriteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteEntity", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_FavoriteEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BF",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FavoriteEntity_Food_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "BF",
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GalleryEntity",
                schema: "BF",
                columns: table => new
                {
                    ImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryEntity", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_GalleryEntity_Food_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "BF",
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                schema: "BF",
                columns: table => new
                {
                    PropertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_Food_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "BF",
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ArticleTitle",
                schema: "BF",
                table: "Article",
                column: "ArticleTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                schema: "BF",
                table: "Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "BF",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "BF",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "BF",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "BF",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "BF",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "BF",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "BF",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticle_ArticleId",
                schema: "BF",
                table: "CommentArticle",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentFood_FoodId",
                schema: "BF",
                table: "CommentFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteEntity_FoodId",
                schema: "BF",
                table: "FavoriteEntity",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteEntity_UserId",
                schema: "BF",
                table: "FavoriteEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_MealId",
                schema: "BF",
                table: "Food",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_SicknessId",
                schema: "BF",
                table: "Food",
                column: "SicknessId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryEntity_FoodId",
                schema: "BF",
                table: "GalleryEntity",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_FoodId",
                schema: "BF",
                table: "Property",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "CommentArticle",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "CommentFood",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "FavoriteEntity",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "GalleryEntity",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Property",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Seo",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Setting",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Slider",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Article",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Food",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Meal",
                schema: "BF");

            migrationBuilder.DropTable(
                name: "Sickness",
                schema: "BF");
        }
    }
}
