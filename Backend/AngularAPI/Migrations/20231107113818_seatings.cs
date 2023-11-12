using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAPI.Migrations
{
    /// <inheritdoc />
    public partial class seatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seatings",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatType = table.Column<int>(type: "int", nullable: false),
                    isBooked = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seatings", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seatings_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "ScreenId");
                });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seatings");
        }
    }
}
