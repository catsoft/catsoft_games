using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class new_day : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_TransactionModels_TransactionId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_TransactionId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Files",
                newName: "TransactionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionModels_BillFileId",
                table: "TransactionModels",
                column: "BillFileId",
                unique: true,
                filter: "[BillFileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionModels_Files_BillFileId",
                table: "TransactionModels",
                column: "BillFileId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionModels_Files_BillFileId",
                table: "TransactionModels");

            migrationBuilder.DropIndex(
                name: "IX_TransactionModels_BillFileId",
                table: "TransactionModels");

            migrationBuilder.RenameColumn(
                name: "TransactionModelId",
                table: "Files",
                newName: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_TransactionId",
                table: "Files",
                column: "TransactionId",
                unique: true,
                filter: "[TransactionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_TransactionModels_TransactionId",
                table: "Files",
                column: "TransactionId",
                principalTable: "TransactionModels",
                principalColumn: "Id");
        }
    }
}
