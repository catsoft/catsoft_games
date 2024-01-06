using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutPageModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPageModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPageModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactsPageModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsPageModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderPageModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPageModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsPageModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsPageModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicesPageModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesPageModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPageModels");

            migrationBuilder.DropTable(
                name: "BlogPageModels");

            migrationBuilder.DropTable(
                name: "ContactsPageModels");

            migrationBuilder.DropTable(
                name: "OrderPageModels");

            migrationBuilder.DropTable(
                name: "ProjectsPageModels");

            migrationBuilder.DropTable(
                name: "ServicesPageModels");
        }
    }
}
