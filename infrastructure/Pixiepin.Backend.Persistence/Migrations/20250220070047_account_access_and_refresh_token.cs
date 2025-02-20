using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pixiepin.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class account_access_and_refresh_token : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "accessToken",
                table: "Accounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "refreshToken",
                table: "Accounts",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accessToken",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "refreshToken",
                table: "Accounts");
        }
    }
}
