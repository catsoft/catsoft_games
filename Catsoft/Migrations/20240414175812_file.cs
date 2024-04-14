using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class fileMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_TransactionModels_TransactionModelId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_TransactionModelId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionModels_BillImageModelId",
                table: "TransactionModels",
                column: "BillImageModelId",
                unique: true,
                filter: "[BillImageModelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionModels_Images_BillImageModelId",
                table: "TransactionModels",
                column: "BillImageModelId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionModels_Images_BillImageModelId",
                table: "TransactionModels");

            migrationBuilder.DropIndex(
                name: "IX_TransactionModels_BillImageModelId",
                table: "TransactionModels");

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
    }
}
