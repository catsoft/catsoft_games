using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectModelGalleryId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProjectModelGalleryId",
                table: "Images",
                column: "ProjectModelGalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ProjectModels_ProjectModelGalleryId",
                table: "Images",
                column: "ProjectModelGalleryId",
                principalTable: "ProjectModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ProjectModels_ProjectModelGalleryId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProjectModelGalleryId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProjectModelGalleryId",
                table: "Images");
        }
    }
}
