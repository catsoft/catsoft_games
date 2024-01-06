using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageModelId",
                table: "MainPageModels",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MainPageModelId",
                table: "Images",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainPageModels_Images_ImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_ImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "ImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "MainPageModelId",
                table: "Images");
        }
    }
}
