using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhPopovich.Migrations
{
    /// <inheritdoc />
    public partial class wa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceModels_ImageModelId",
                table: "ServiceModels");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModels_ImageModelId",
                table: "ProjectModels");

            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageModelId",
                table: "ServiceModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageModelId",
                table: "ProjectModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MetaImageModelId",
                table: "MainPageModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModels_ImageModelId",
                table: "ServiceModels",
                column: "ImageModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModels_ImageModelId",
                table: "ProjectModels",
                column: "ImageModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels",
                column: "MetaImageModelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceModels_ImageModelId",
                table: "ServiceModels");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModels_ImageModelId",
                table: "ProjectModels");

            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageModelId",
                table: "ServiceModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageModelId",
                table: "ProjectModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MetaImageModelId",
                table: "MainPageModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModels_ImageModelId",
                table: "ServiceModels",
                column: "ImageModelId",
                unique: true,
                filter: "[ImageModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModels_ImageModelId",
                table: "ProjectModels",
                column: "ImageModelId",
                unique: true,
                filter: "[ImageModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels",
                column: "MetaImageModelId",
                unique: true,
                filter: "[MetaImageModelId] IS NOT NULL");
        }
    }
}
