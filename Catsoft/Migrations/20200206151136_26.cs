using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ArticleModelId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    ImageModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleModels_Images_ImageModelId",
                        column: x => x.ImageModelId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleModels_ImageModelId",
                table: "ArticleModels",
                column: "ImageModelId",
                unique: true,
                filter: "[ImageModelId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleModels");

            migrationBuilder.DropColumn(
                name: "ArticleModelId",
                table: "Images");
        }
    }
}
