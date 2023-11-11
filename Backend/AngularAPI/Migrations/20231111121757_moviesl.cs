using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAPI.Migrations
{
    /// <inheritdoc />
    public partial class moviesl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
