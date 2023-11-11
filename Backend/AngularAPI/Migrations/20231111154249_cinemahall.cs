using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAPI.Migrations
{
    /// <inheritdoc />
    public partial class cinemahall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_Locations_LocationId",
                table: "movies");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "movies",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_movies_LocationId",
                table: "movies",
                newName: "IX_movies_CityId");

            migrationBuilder.CreateTable(
                name: "CinemaHalls",
                columns: table => new
                {
                    CinemaHallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaHallName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TicketCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHalls", x => x.CinemaHallId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_movies_cities_CityId",
                table: "movies",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_cities_CityId",
                table: "movies");

            migrationBuilder.DropTable(
                name: "CinemaHalls");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "movies",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_movies_CityId",
                table: "movies",
                newName: "IX_movies_LocationId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_movies_Locations_LocationId",
                table: "movies",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
