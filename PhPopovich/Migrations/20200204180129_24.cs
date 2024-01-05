using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MainPageModelGalleryId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_MainPageModelGalleryId",
                table: "Images",
                column: "MainPageModelGalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MainPageModels_MainPageModelGalleryId",
                table: "Images",
                column: "MainPageModelGalleryId",
                principalTable: "MainPageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MainPageModels_MainPageModelGalleryId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_MainPageModelGalleryId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MainPageModelGalleryId",
                table: "Images");
        }
    }
}
