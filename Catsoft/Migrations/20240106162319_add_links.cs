using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class add_links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextResourceValueModel");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "TextResourceValuesModels");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "TextResourceValuesModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TextResourceModelId",
                table: "TextResourceValuesModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "TextResourceValuesModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TextResourceModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextResourceModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextResources_TextResourceModelId",
                table: "TextResourceValuesModels",
                column: "TextResourceModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextResources_TextResourceModels_TextResourceModelId",
                table: "TextResourceValuesModels",
                column: "TextResourceModelId",
                principalTable: "TextResourceModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextResources_TextResourceModels_TextResourceModelId",
                table: "TextResourceValuesModels");

            migrationBuilder.DropTable(
                name: "TextResourceModels");

            migrationBuilder.DropIndex(
                name: "IX_TextResources_TextResourceModelId",
                table: "TextResourceValuesModels");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "TextResourceValuesModels");

            migrationBuilder.DropColumn(
                name: "TextResourceModelId",
                table: "TextResourceValuesModels");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "TextResourceValuesModels");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "TextResourceValuesModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TextResourceValueModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    TextResourceModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextResourceValueModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextResourceValueModel_TextResources_TextResourceModelId",
                        column: x => x.TextResourceModelId,
                        principalTable: "TextResourceValuesModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextResourceValueModel_TextResourceModelId",
                table: "TextResourceValueModel",
                column: "TextResourceModelId");
        }
    }
}
