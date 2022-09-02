using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    public partial class AddUsersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 23, "Bucuresti", "teo.steaua07@yahoo.com", "Teodor", "Nicolau" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 24, "Constanta", "ioana.dinca@yahoo.com", "Ioana", "Dinca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
