using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wemusic.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Artists_ArtistId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_ArtistId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Artists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtistId",
                table: "Artists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ArtistId",
                table: "Artists",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Artists_ArtistId",
                table: "Artists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
