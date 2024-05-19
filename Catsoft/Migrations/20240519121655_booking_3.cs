using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class booking_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointRules_AppointTimes_AppointTimeId",
                table: "AppointRules");

            migrationBuilder.DropIndex(
                name: "IX_AppointRules_AppointTimeId",
                table: "AppointRules");

            migrationBuilder.DropColumn(
                name: "AppointTimeId",
                table: "AppointRules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppointTimeId",
                table: "AppointRules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointRules_AppointTimeId",
                table: "AppointRules",
                column: "AppointTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointRules_AppointTimes_AppointTimeId",
                table: "AppointRules",
                column: "AppointTimeId",
                principalTable: "AppointTimes",
                principalColumn: "Id");
        }
    }
}
