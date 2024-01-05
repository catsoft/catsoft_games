using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstaLink",
                table: "ContactsPageModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VkLink",
                table: "ContactsPageModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstaLink",
                table: "ContactsPageModels");

            migrationBuilder.DropColumn(
                name: "VkLink",
                table: "ContactsPageModels");
        }
    }
}
