using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wemusic.Migrations
{
    /// <inheritdoc />
    public partial class updateuserkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_userId",
                table: "Playlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_userId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Playlists");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Playlists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserName",
                table: "Playlists",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserName",
                table: "Playlists",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserName",
                table: "Playlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_UserName",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Playlists");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "passwordHash");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Playlists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_userId",
                table: "Playlists",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_userId",
                table: "Playlists",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
