using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caloracker1.Migrations
{
    /// <inheritdoc />
    public partial class daily : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyCalorie = table.Column<int>(type: "int", nullable: true),
                    TotalBudget = table.Column<int>(type: "int", nullable: true),
                    Breakfast = table.Column<int>(type: "int", nullable: true),
                    Lunch = table.Column<int>(type: "int", nullable: true),
                    Dinner = table.Column<int>(type: "int", nullable: true),
                    CupWater = table.Column<int>(type: "int", nullable: true),
                    TotalKarbs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalProteins = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalFats = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Track_UserId",
                table: "Track",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.CreateTable(
                name: "DailyTracker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breakfast = table.Column<int>(type: "int", nullable: true),
                    CupWater = table.Column<int>(type: "int", nullable: true),
                    DailyCalorie = table.Column<int>(type: "int", nullable: true),
                    Dinner = table.Column<int>(type: "int", nullable: true),
                    Lunch = table.Column<int>(type: "int", nullable: true),
                    TotalBudget = table.Column<int>(type: "int", nullable: true),
                    TotalFats = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalKarbs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalProteins = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTracker", x => x.Id);
                });
        }
    }
}
