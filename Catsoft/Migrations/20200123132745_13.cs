using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhPopovich.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailModels_AboutPageModels_AboutPageModelId",
                table: "EmailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModels_AboutPageModels_AboutPageModelId",
                table: "PhoneModels");

            migrationBuilder.DropIndex(
                name: "IX_PhoneModels_AboutPageModelId",
                table: "PhoneModels");

            migrationBuilder.DropIndex(
                name: "IX_EmailModels_AboutPageModelId",
                table: "EmailModels");

            migrationBuilder.DropColumn(
                name: "AboutPageModelId",
                table: "PhoneModels");

            migrationBuilder.DropColumn(
                name: "AboutPageModelId",
                table: "EmailModels");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactsPageModelId",
                table: "PhoneModels",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContactsPageModelId",
                table: "EmailModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModels_ContactsPageModelId",
                table: "PhoneModels",
                column: "ContactsPageModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailModels_ContactsPageModelId",
                table: "EmailModels",
                column: "ContactsPageModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailModels_ContactsPageModels_ContactsPageModelId",
                table: "EmailModels",
                column: "ContactsPageModelId",
                principalTable: "ContactsPageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModels_ContactsPageModels_ContactsPageModelId",
                table: "PhoneModels",
                column: "ContactsPageModelId",
                principalTable: "ContactsPageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailModels_ContactsPageModels_ContactsPageModelId",
                table: "EmailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModels_ContactsPageModels_ContactsPageModelId",
                table: "PhoneModels");

            migrationBuilder.DropIndex(
                name: "IX_PhoneModels_ContactsPageModelId",
                table: "PhoneModels");

            migrationBuilder.DropIndex(
                name: "IX_EmailModels_ContactsPageModelId",
                table: "EmailModels");

            migrationBuilder.DropColumn(
                name: "ContactsPageModelId",
                table: "PhoneModels");

            migrationBuilder.DropColumn(
                name: "ContactsPageModelId",
                table: "EmailModels");

            migrationBuilder.AddColumn<Guid>(
                name: "AboutPageModelId",
                table: "PhoneModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AboutPageModelId",
                table: "EmailModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModels_AboutPageModelId",
                table: "PhoneModels",
                column: "AboutPageModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailModels_AboutPageModelId",
                table: "EmailModels",
                column: "AboutPageModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailModels_AboutPageModels_AboutPageModelId",
                table: "EmailModels",
                column: "AboutPageModelId",
                principalTable: "AboutPageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModels_AboutPageModels_AboutPageModelId",
                table: "PhoneModels",
                column: "AboutPageModelId",
                principalTable: "AboutPageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
