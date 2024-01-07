using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class remove_meta_image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPageModels_Images_MetaImageModelId",
                table: "BlogPageModels");

            migrationBuilder.DropForeignKey(
                name: "FK_MainPageModels_Images_MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PreOrderPageModels_Images_MetaImageModelId",
                table: "PreOrderPageModels");

            migrationBuilder.DropIndex(
                name: "IX_PreOrderPageModels_MetaImageModelId",
                table: "PreOrderPageModels");

            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropIndex(
                name: "IX_BlogPageModels_MetaImageModelId",
                table: "BlogPageModels");

            migrationBuilder.DropColumn(
                name: "MetaImageModelId",
                table: "PreOrderPageModels");

            migrationBuilder.DropColumn(
                name: "MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "BlogPageModelMetaId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MainPageModelMetaId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MetaImageModelId",
                table: "BlogPageModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MetaImageModelId",
                table: "PreOrderPageModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MetaImageModelId",
                table: "MainPageModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BlogPageModelMetaId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MainPageModelMetaId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaImageModelId",
                table: "BlogPageModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreOrderPageModels_MetaImageModelId",
                table: "PreOrderPageModels",
                column: "MetaImageModelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PreOrderPageModels_Images_MetaImageModelId",
                table: "PreOrderPageModels",
                column: "MetaImageModelId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
