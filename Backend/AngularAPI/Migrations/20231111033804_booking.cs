using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAPI.Migrations
{
    /// <inheritdoc />
    public partial class booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            

           

            migrationBuilder.CreateTable(
                name: "BookingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheaterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedSeatsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalFare = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingInfo", x => x.Id);
                });

           

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "BookingInfo");

           

           

           

            
        }
    }
}
