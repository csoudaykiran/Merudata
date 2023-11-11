using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAPI.Migrations
{
    /// <inheritdoc />
    public partial class movie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_Locations_LocationId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_LocationId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "movies");
        }
    }
}
