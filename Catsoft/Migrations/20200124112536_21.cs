using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_Images_ImageModelId",
                table: "ProjectModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModel",
                table: "ProjectModel");

            migrationBuilder.RenameTable(
                name: "ProjectModel",
                newName: "ProjectModels");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModel_ImageModelId",
                table: "ProjectModels",
                newName: "IX_ProjectModels_ImageModelId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectsCount",
                table: "MainPageModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicesCount",
                table: "MainPageModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModels",
                table: "ProjectModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModels_Images_ImageModelId",
                table: "ProjectModels",
                column: "ImageModelId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModels_Images_ImageModelId",
                table: "ProjectModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModels",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "ProjectsCount",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "ServicesCount",
                table: "MainPageModels");

            migrationBuilder.RenameTable(
                name: "ProjectModels",
                newName: "ProjectModel");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModels_ImageModelId",
                table: "ProjectModel",
                newName: "IX_ProjectModel_ImageModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModel",
                table: "ProjectModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_Images_ImageModelId",
                table: "ProjectModel",
                column: "ImageModelId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
