using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainPageModels_Images_ImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_ImageModelId",
                table: "MainPageModels");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MainPageModels_MainPageModelId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_MainPageModelId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_MainPageModels_ImageModelId",
                table: "MainPageModels",
                column: "ImageModelId",
                unique: true,
                filter: "[ImageModelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MainPageModels_Images_ImageModelId",
                table: "MainPageModels",
                column: "ImageModelId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
