using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "ProjectModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "MainPageModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "BlogPageModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "ArticleModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "MainPageModels");

            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "BlogPageModels");

            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "ArticleModels");
        }
    }
}
