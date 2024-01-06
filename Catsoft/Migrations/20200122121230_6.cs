using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "MainPageModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AdminModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AdminModels");
        }
    }
}
