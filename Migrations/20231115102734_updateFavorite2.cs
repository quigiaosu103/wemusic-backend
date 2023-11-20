using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wemusic.Migrations
{
    /// <inheritdoc />
    public partial class updateFavorite2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Users_UserName",
                table: "Favorite");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Favorite",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Users_UserName",
                table: "Favorite",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Users_UserName",
                table: "Favorite");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Favorite",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Users_UserName",
                table: "Favorite",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName");
        }
    }
}
