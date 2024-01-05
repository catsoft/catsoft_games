using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPageModels");

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "MainPageModels",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaImageModelId",
                table: "MainPageModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "MainPageModels",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BlogPageModelMetaId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MainPageModelMetaId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "BlogPageModels",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaImageModelId",
                table: "BlogPageModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "BlogPageModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "ArticleModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "ArticleModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                table: "ArticleModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels",
                column: "MetaImageModelId",
                unique: true,
                filter: "[MetaImageModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPageModels_MetaImageModelId",
                table: "BlogPageModels",
                column: "MetaImageModelId",
                unique: true,
                filter: "[MetaImageModelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPageModels_Images_MetaImageModelId",
                table: "BlogPageModels",
                column: "MetaImageModelId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MainPageModels_Images_MetaImageModelId",
                table: "MainPageModels",
                column: "MetaImageModelId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPageModels_Images_MetaImageModelId",
                table: "BlogPageModels");

            migrationBuilder.DropForeignKey(
                name: "FK_MainPageModels_Images_MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropIndex(
                name: "IX_BlogPageModels_MetaImageModelId",
                table: "BlogPageModels");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "BlogPageModelMetaId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MainPageModelMetaId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "BlogPageModels");

            migrationBuilder.DropColumn(
                name: "MetaImageModelId",
                table: "BlogPageModels");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "BlogPageModels");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "ArticleModels");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "ArticleModels");

            migrationBuilder.DropColumn(
                name: "PageTitle",
                table: "ArticleModels");

            migrationBuilder.CreateTable(
                name: "OrderPageModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPageModels", x => x.Id);
                });
        }
    }
}
