using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caloracker1.Migrations
{
    /// <inheritdoc />
    public partial class ll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Meal_MealId",
                table: "Meal");

            migrationBuilder.DropIndex(
                name: "IX_Meal_MealId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Meal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Meal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meal_MealId",
                table: "Meal",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Meal_MealId",
                table: "Meal",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id");
        }
    }
}
