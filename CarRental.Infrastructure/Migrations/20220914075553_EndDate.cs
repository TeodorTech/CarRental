using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    public partial class EndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "CarId", "EndDate", "StartDate", "UserId" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 14, 10, 55, 53, 29, DateTimeKind.Local).AddTicks(2351), new DateTime(2022, 9, 14, 10, 55, 53, 29, DateTimeKind.Local).AddTicks(2316), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Bookings");
        }
    }
}
