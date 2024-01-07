using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class text_value_resources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextResourceValuesModels",
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
                    table.PrimaryKey("PK_TextResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextResourceValueModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    TextResourceModelId = table.Column<Guid>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextResourceValueModel");

            migrationBuilder.DropTable(
                name: "TextResourceValuesModels");
        }
    }
}
