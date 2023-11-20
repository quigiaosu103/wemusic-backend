using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wemusic.Migrations
{
    /// <inheritdoc />
    public partial class updateuser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumType",
                table: "Playlists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlbumType",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
