using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class stupid_mistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionModels_AccountModels_AccountFromId",
                table: "TransactionModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionModels_AccountModels_AccountToId",
                table: "TransactionModels");

            migrationBuilder.RenameColumn(
                name: "AccountToId",
                table: "TransactionModels",
                newName: "AccountToModelId");

            migrationBuilder.RenameColumn(
                name: "AccountFromId",
                table: "TransactionModels",
                newName: "AccountFromModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionModels_AccountToId",
                table: "TransactionModels",
                newName: "IX_TransactionModels_AccountToModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionModels_AccountFromId",
                table: "TransactionModels",
                newName: "IX_TransactionModels_AccountFromModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionModels_AccountModels_AccountFromModelId",
                table: "TransactionModels",
                column: "AccountFromModelId",
                principalTable: "AccountModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionModels_AccountModels_AccountToModelId",
                table: "TransactionModels",
                column: "AccountToModelId",
                principalTable: "AccountModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionModels_AccountModels_AccountFromModelId",
                table: "TransactionModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionModels_AccountModels_AccountToModelId",
                table: "TransactionModels");

            migrationBuilder.RenameColumn(
                name: "AccountToModelId",
                table: "TransactionModels",
                newName: "AccountToId");

            migrationBuilder.RenameColumn(
                name: "AccountFromModelId",
                table: "TransactionModels",
                newName: "AccountFromId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionModels_AccountToModelId",
                table: "TransactionModels",
                newName: "IX_TransactionModels_AccountToId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionModels_AccountFromModelId",
                table: "TransactionModels",
                newName: "IX_TransactionModels_AccountFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionModels_AccountModels_AccountFromId",
                table: "TransactionModels",
                column: "AccountFromId",
                principalTable: "AccountModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionModels_AccountModels_AccountToId",
                table: "TransactionModels",
                column: "AccountToId",
                principalTable: "AccountModels",
                principalColumn: "Id");
        }
    }
}
