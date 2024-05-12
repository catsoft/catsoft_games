using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class video_updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "GameModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameTagModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTagModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameModelGameTagModel",
                columns: table => new
                {
                    GameModelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameTagModelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModelGameTagModel", x => new { x.GameModelsId, x.GameTagModelsId });
                    table.ForeignKey(
                        name: "FK_GameModelGameTagModel_GameModels_GameModelsId",
                        column: x => x.GameModelsId,
                        principalTable: "GameModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameModelGameTagModel_GameTagModels_GameTagModelsId",
                        column: x => x.GameTagModelsId,
                        principalTable: "GameTagModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameModelGameTagModel_GameTagModelsId",
                table: "GameModelGameTagModel",
                column: "GameTagModelsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameModelGameTagModel");

            migrationBuilder.DropTable(
                name: "GameTagModels");

            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "GameModels");
        }
    }
}
