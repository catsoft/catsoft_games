using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class booking_persondetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instant",
                table: "PersonBookings");

            migrationBuilder.AddColumn<int>(
                name: "PersonBookingSource",
                table: "PersonBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SelectedTimes",
                table: "PersonBookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonBookingSource",
                table: "PersonBookings");

            migrationBuilder.DropColumn(
                name: "SelectedTimes",
                table: "PersonBookings");

            migrationBuilder.AddColumn<bool>(
                name: "Instant",
                table: "PersonBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
