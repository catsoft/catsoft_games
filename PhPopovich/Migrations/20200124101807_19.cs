using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ServicesPageModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ServiceModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ProjectsPageModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ProjectModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "PhoneModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "OrderPageModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "MainPageModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "EmailModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ContactsPageModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "BlogPageModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "AdminModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "AboutPageModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
