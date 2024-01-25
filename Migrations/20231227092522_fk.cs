using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caloracker1.Migrations
{
    /// <inheritdoc />
    public partial class fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_AspNetUsers_CalorackerUserId",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_CalorackerUserId",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "CalorackerUserId",
                table: "Track");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Track",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Track_UserId",
                table: "Track",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_AspNetUsers_UserId",
                table: "Track",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_AspNetUsers_UserId",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_UserId",
                table: "Track");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Track",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalorackerUserId",
                table: "Track",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Track_CalorackerUserId",
                table: "Track",
                column: "CalorackerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_AspNetUsers_CalorackerUserId",
                table: "Track",
                column: "CalorackerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
