using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wemusic.Migrations
{
    /// <inheritdoc />
    public partial class updateFavorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorite_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteSong",
                columns: table => new
                {
                    FavoritesId = table.Column<int>(type: "int", nullable: false),
                    SongsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteSong", x => new { x.FavoritesId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_FavoriteSong_Favorite_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "Favorite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserName",
                table: "Favorite",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSong_SongsId",
                table: "FavoriteSong",
                column: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteSong");

            migrationBuilder.DropTable(
                name: "Favorite");
        }
    }
}
