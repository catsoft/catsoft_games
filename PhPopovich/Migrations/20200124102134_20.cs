using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ServicesPageModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ServiceModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ProjectsPageModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ProjectModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "PhoneModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "OrderPageModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "MainPageModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Files",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "EmailModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ContactsPageModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "BlogPageModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "AdminModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "AboutPageModels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "ServicesPageModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "ServiceModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "ProjectsPageModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "PhoneModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "OrderPageModels");

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
                table: "EmailModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "ContactsPageModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "BlogPageModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AdminModels");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AboutPageModels");
        }
    }
}
