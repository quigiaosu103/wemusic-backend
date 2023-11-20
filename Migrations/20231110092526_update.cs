using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wemusic.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumSong");

            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "albumType",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "img",
                table: "Songs",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Genres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Artists",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "totalSongs",
                table: "Albums",
                newName: "TotalSongs");

            migrationBuilder.RenameColumn(
                name: "releaseDate",
                table: "Albums",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Albums",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "albumId",
                table: "Songs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ArtistGenre",
                columns: table => new
                {
                    ArtistsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenresId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGenre", x => new { x.ArtistsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_ArtistGenre_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_albumId",
                table: "Songs",
                column: "albumId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenre_GenresId",
                table: "ArtistGenre",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_albumId",
                table: "Songs",
                column: "albumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_albumId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "ArtistGenre");

            migrationBuilder.DropIndex(
                name: "IX_Songs_albumId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "albumId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Songs",
                newName: "img");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Artists",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "TotalSongs",
                table: "Albums",
                newName: "totalSongs");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Albums",
                newName: "releaseDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Albums",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "albumType",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AlbumSong",
                columns: table => new
                {
                    AlbumsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SongsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumSong", x => new { x.AlbumsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_AlbumSong_Albums_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SongsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtistId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumSong_SongsId",
                table: "AlbumSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsId",
                table: "GenreSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArtistId",
                table: "Images",
                column: "ArtistId");
        }
    }
}
