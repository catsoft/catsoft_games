using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class files4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_TransactionModels_TransactionId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_TransactionId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Images",
                newName: "TransactionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TransactionModelId",
                table: "Images",
                column: "TransactionModelId",
                unique: true,
                filter: "[TransactionModelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_TransactionModels_TransactionModelId",
                table: "Images",
                column: "TransactionModelId",
                principalTable: "TransactionModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_TransactionModels_TransactionModelId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_TransactionModelId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "TransactionModelId",
                table: "Images",
                newName: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TransactionId",
                table: "Images",
                column: "TransactionId",
                unique: true,
                filter: "[TransactionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_TransactionModels_TransactionId",
                table: "Images",
                column: "TransactionId",
                principalTable: "TransactionModels",
                principalColumn: "Id");
        }
    }
}
