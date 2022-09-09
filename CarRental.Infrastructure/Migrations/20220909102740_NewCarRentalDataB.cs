using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    public partial class NewCarRentalDataB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Make", "Model", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, "Porche", "911", 350f, 2008 },
                    { 2, "Porche", "Cayene", 500f, 2020 },
                    { 3, "Porche", "Panamera", 450f, 2016 },
                    { 4, "Porche", "918", 1050f, 2021 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 23, "Bucuresti", "teo.steaua07@yahoo.com", "Teodor", "Nicolau" },
                    { 2, 24, "Constanta", "ioana.dinca@yahoo.com", "Ioana", "Dinca" },
                    { 3, 24, "Constanta", "alex.dinca@yahoo.com", "Alex", "Dinca" },
                    { 4, 21, "Cluj", "andrei.ion@yahoo.com", "Andrei", "Ion" },
                    { 5, 45, "Timisoara", "=george.enescu@yahoo.com", "George", "Enescu" },
                    { 6, 38, "Constanta", "cristiano.ronaldo@yahoo.com", "Cristiano", "Ronaldo" },
                    { 7, 99, "Suceava", "leonardo.davinci@yahoo.com", "Leonardo", "Davinci" },
                    { 8, 49, "Timisoara", "brad.pitt@yahoo.com", "Brad", "Pitt" },
                    { 9, 45, "Bucuresti", "megan.fox@yahoo.com", "Megan", "Fox" },
                    { 10, 50, "Constanta", "barak.obama@yahoo.com", "Barack", "Obama" },
                    { 11, 30, "Cluj", "steph.curry@yahoo.com", "Steph", "Curry" },
                    { 12, 35, "Constanta", "lebron.james@yahoo.com", "James", "LeBron" },
                    { 13, 35, "Constanta", "lebron.james@yahoo.com", "James", "LeBron" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
