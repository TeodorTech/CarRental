using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    public partial class ImageLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 9, 23, 8, 57, 6, 685, DateTimeKind.Local).AddTicks(4212), new DateTime(2022, 9, 23, 8, 57, 6, 685, DateTimeKind.Local).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageLink",
                value: "https://thumbs.dreamstime.com/b/tula-russia-march-porsche-turbo-s-white-sports-car-coupe-isolated-white-background-d-rendering-tula-russia-march-porsche-turbo-225956942.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageLink",
                value: "https://thumbs.dreamstime.com/b/tula-russia-march-porsche-turbo-s-white-sports-car-coupe-isolated-white-background-d-rendering-tula-russia-march-porsche-turbo-225956942.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageLink",
                value: "https://thumbs.dreamstime.com/b/tula-russia-march-porsche-turbo-s-white-sports-car-coupe-isolated-white-background-d-rendering-tula-russia-march-porsche-turbo-225956942.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageLink",
                value: "https://thumbs.dreamstime.com/b/tula-russia-march-porsche-turbo-s-white-sports-car-coupe-isolated-white-background-d-rendering-tula-russia-march-porsche-turbo-225956942.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 9, 14, 10, 55, 53, 29, DateTimeKind.Local).AddTicks(2351), new DateTime(2022, 9, 14, 10, 55, 53, 29, DateTimeKind.Local).AddTicks(2316) });
        }
    }
}
