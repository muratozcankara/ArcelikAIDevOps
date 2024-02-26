using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcelikWebApi.Migrations
{
    /// <inheritdoc />
    public partial class DataIntegrity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isTutorialDone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isWatchedAll",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isTutorialDone",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isWatchedAll",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
