using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAPI.Migrations
{
    /// <inheritdoc />
    public partial class cinemahallrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_MovieId",
                table: "CinemaHalls",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_movies_MovieId",
                table: "CinemaHalls",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_movies_MovieId",
                table: "CinemaHalls");

            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_MovieId",
                table: "CinemaHalls");
        }
    }
}
