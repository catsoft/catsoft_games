using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhPopovich.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "MetaImageModelId",
                table: "MainPageModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels",
                column: "MetaImageModelId",
                unique: true,
                filter: "[MetaImageModelId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels");

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
                name: "IX_MainPageModels_MetaImageModelId",
                table: "MainPageModels",
                column: "MetaImageModelId",
                unique: true);
        }
    }
}
