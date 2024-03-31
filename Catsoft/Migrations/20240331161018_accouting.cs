using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class accouting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActualAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlannedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    ForRecell = table.Column<bool>(type: "bit", nullable: false),
                    TemplateAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTemplate = table.Column<bool>(type: "bit", nullable: false),
                    TemplateTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: false),
                    RecurringFrequency = table.Column<int>(type: "int", nullable: false),
                    RecurringStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecurringEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Items = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionModels_AccountModels_AccountFromId",
                        column: x => x.AccountFromId,
                        principalTable: "AccountModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionModels_AccountModels_AccountToId",
                        column: x => x.AccountToId,
                        principalTable: "AccountModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionModels_TransactionModels_TemplateTransactionId",
                        column: x => x.TemplateTransactionId,
                        principalTable: "TransactionModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_TransactionId",
                table: "Files",
                column: "TransactionId",
                unique: true,
                filter: "[TransactionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionModels_AccountFromId",
                table: "TransactionModels",
                column: "AccountFromId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionModels_AccountToId",
                table: "TransactionModels",
                column: "AccountToId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionModels_TemplateTransactionId",
                table: "TransactionModels",
                column: "TemplateTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_TransactionModels_TransactionId",
                table: "Files",
                column: "TransactionId",
                principalTable: "TransactionModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_TransactionModels_TransactionId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "TransactionModels");

            migrationBuilder.DropTable(
                name: "AccountModels");

            migrationBuilder.DropIndex(
                name: "IX_Files_TransactionId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Files");
        }
    }
}
