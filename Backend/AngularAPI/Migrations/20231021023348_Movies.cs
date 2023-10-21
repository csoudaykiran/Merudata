using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAPI.Migrations
{
    /// <inheritdoc />
    public partial class Movies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    ImgLink = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Censorship = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", nullable: false),
                    TrailerLink = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
