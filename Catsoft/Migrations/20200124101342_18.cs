using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "ServicesPageModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesText",
                table: "ServicesPageModels",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "ProjectsPageModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesText",
                table: "ProjectsPageModels",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "PhoneModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "OrderPageModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Menus",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "MainPageModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectModelId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceModelId",
                table: "Images",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Files",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "EmailModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "ContactsPageModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "BlogPageModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "AdminModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "AboutPageModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    ImageModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModel_Images_ImageModelId",
                        column: x => x.ImageModelId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ServiceModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    ImageModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceModels_Images_ImageModelId",
                        column: x => x.ImageModelId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModel_ImageModelId",
                table: "ProjectModel",
                column: "ImageModelId",
                unique: true,
                filter: "[ImageModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModels_ImageModelId",
                table: "ServiceModels",
                column: "ImageModelId",
                unique: true,
                filter: "[ImageModelId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectModel");

            migrationBuilder.DropTable(
                name: "ServiceModels");

            migrationBuilder.DropColumn(
                name: "ServicesText",
                table: "ServicesPageModels");

            migrationBuilder.DropColumn(
                name: "ServicesText",
                table: "ProjectsPageModels");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ServiceModelId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "ServicesPageModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "ProjectsPageModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "PhoneModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "OrderPageModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "MainPageModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "EmailModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "ContactsPageModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "BlogPageModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "AdminModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "AboutPageModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
