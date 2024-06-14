using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class booking_deleting2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointTimes_PersonBookings_PersonBookingId",
                table: "AppointTimes");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointTimes_PersonBookings_PersonBookingId",
                table: "AppointTimes",
                column: "PersonBookingId",
                principalTable: "PersonBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointTimes_PersonBookings_PersonBookingId",
                table: "AppointTimes");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointTimes_PersonBookings_PersonBookingId",
                table: "AppointTimes",
                column: "PersonBookingId",
                principalTable: "PersonBookings",
                principalColumn: "Id");
        }
    }
}
