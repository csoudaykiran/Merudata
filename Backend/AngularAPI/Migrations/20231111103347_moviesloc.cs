using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAPI.Migrations
{
    /// <inheritdoc />
    public partial class moviesloc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_Locations_LocationId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_LocationId",
                table: "movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_movies_LocationId",
                table: "movies",
                column: "LocationId");

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
