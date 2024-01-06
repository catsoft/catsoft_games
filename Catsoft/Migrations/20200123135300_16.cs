using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ContactsPageModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ContactsPageModels");
        }
    }
}
