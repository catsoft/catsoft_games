using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class files : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BillImageId",
                table: "TransactionModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_TransactionModels_TransactionId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_TransactionId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "BillImageId",
                table: "TransactionModels");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Images");
        }
    }
}
