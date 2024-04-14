using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class files9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForRecell",
                table: "TransactionModels",
                newName: "ForResell");

            migrationBuilder.AlterColumn<float>(
                name: "PlannedAmount",
                table: "TransactionModels",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "ActualAmount",
                table: "TransactionModels",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForResell",
                table: "TransactionModels",
                newName: "ForRecell");

            migrationBuilder.AlterColumn<double>(
                name: "PlannedAmount",
                table: "TransactionModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "ActualAmount",
                table: "TransactionModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
