using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caloracker1.Migrations
{
    /// <inheritdoc />
    public partial class fk3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_AspNetUsers_UserId",
                table: "Track");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_AspNetUsers_UserId",
                table: "Track",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_AspNetUsers_UserId",
                table: "Track");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_AspNetUsers_UserId",
                table: "Track",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
