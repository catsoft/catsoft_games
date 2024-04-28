using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class amount_remove_quatntiny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeAmount",
                table: "TransactionModels");

            migrationBuilder.DropColumn(
                name: "TypeQuantity",
                table: "TransactionModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TypeAmount",
                table: "TransactionModels",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TypeQuantity",
                table: "TransactionModels",
                type: "real",
                nullable: true);
        }
    }
}
