using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MainPageModels_MainPageModelId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Images_MainPageModelId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "EmailModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AboutPageModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailModels_AboutPageModels_AboutPageModelId",
                        column: x => x.AboutPageModelId,
                        principalTable: "AboutPageModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PhoneModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AboutPageModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneModels_AboutPageModels_AboutPageModelId",
                        column: x => x.AboutPageModelId,
                        principalTable: "AboutPageModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainPageModels_ImageModelId",
                table: "MainPageModels",
                column: "ImageModelId",
                unique: true,
                filter: "[ImageModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmailModels_AboutPageModelId",
                table: "EmailModels",
                column: "AboutPageModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModels_AboutPageModelId",
                table: "PhoneModels",
                column: "AboutPageModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainPageModels_Images_ImageModelId",
                table: "MainPageModels",
                column: "ImageModelId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainPageModels_Images_ImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropTable(
                name: "EmailModels");

            migrationBuilder.DropTable(
                name: "PhoneModels");

            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_ImageModelId",
                table: "MainPageModels");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_MainPageModelId",
                table: "Images",
                column: "MainPageModelId",
                unique: true,
                filter: "[MainPageModelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MainPageModels_MainPageModelId",
                table: "Images",
                column: "MainPageModelId",
                principalTable: "MainPageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
