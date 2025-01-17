using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wishlist.Migrations
{
    /// <inheritdoc />
    public partial class userIdLinked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Lista",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_UserId",
                table: "Lista",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lista_AspNetUsers_UserId",
                table: "Lista",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lista_AspNetUsers_UserId",
                table: "Lista");

            migrationBuilder.DropIndex(
                name: "IX_Lista_UserId",
                table: "Lista");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lista");
        }
    }
}
