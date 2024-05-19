using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Booked = table.Column<bool>(type: "bit", nullable: false),
                    Instant = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonBookings_PersonModels_PersonModelId",
                        column: x => x.PersonModelId,
                        principalTable: "PersonModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppointTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeStart = table.Column<TimeOnly>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeOnly>(type: "time", nullable: false),
                    RentPlaceModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonBookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Booked = table.Column<bool>(type: "bit", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointTimes_PersonBookings_PersonBookingId",
                        column: x => x.PersonBookingId,
                        principalTable: "PersonBookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointTimes_RentPlaces_RentPlaceModelId",
                        column: x => x.RentPlaceModelId,
                        principalTable: "RentPlaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppointRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateStart = table.Column<DateOnly>(type: "date", nullable: false),
                    DateEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeStart = table.Column<TimeOnly>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeOnly>(type: "time", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppointRuleType = table.Column<int>(type: "int", nullable: false),
                    AppointTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointRules_AppointTimes_AppointTimeId",
                        column: x => x.AppointTimeId,
                        principalTable: "AppointTimes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointRules_AppointTimeId",
                table: "AppointRules",
                column: "AppointTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointTimes_PersonBookingId",
                table: "AppointTimes",
                column: "PersonBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointTimes_RentPlaceModelId",
                table: "AppointTimes",
                column: "RentPlaceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonBookings_PersonModelId",
                table: "PersonBookings",
                column: "PersonModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointRules");

            migrationBuilder.DropTable(
                name: "AppointTimes");

            migrationBuilder.DropTable(
                name: "PersonBookings");

            migrationBuilder.DropTable(
                name: "RentPlaces");

            migrationBuilder.DropTable(
                name: "PersonModels");
        }
    }
}
