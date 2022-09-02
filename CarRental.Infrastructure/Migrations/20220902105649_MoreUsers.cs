using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    public partial class MoreUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, 24, "Constanta", "ioana.dinca@yahoo.com", "Alex", "Dinca" },
                    { 4, 21, "Constanta", "ioana.dinca@yahoo.com", "Andrei", "Ion" },
                    { 5, 45, "Constanta", "ioana.dinca@yahoo.com", "George", "Enescu" },
                    { 6, 38, "Constanta", "ioana.dinca@yahoo.com", "Cristiano", "Ronaldo" },
                    { 7, 99, "Constanta", "ioana.dinca@yahoo.com", "Leonardo", "Davinci" },
                    { 8, 49, "Constanta", "ioana.dinca@yahoo.com", "Brad", "Pitt" },
                    { 9, 45, "Constanta", "ioana.dinca@yahoo.com", "Megan", "Fox" },
                    { 10, 50, "Constanta", "ioana.dinca@yahoo.com", "barack", "Obama" },
                    { 11, 30, "Constanta", "ioana.dinca@yahoo.com", "Steph", "Curry" },
                    { 12, 35, "Constanta", "ioana.dinca@yahoo.com", "James", "LeBron" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
