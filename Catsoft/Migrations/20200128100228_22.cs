using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EmailOrPhone = table.Column<string>(nullable: true),
                    DesireDate = table.Column<DateTime>(nullable: false),
                    About = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderModels");
        }
    }
}
