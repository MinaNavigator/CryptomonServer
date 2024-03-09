using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptomonServer.Migrations
{
    /// <inheritdoc />
    public partial class Balance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CoinBalance",
                table: "Accounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MinaBalance",
                table: "Accounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoinBalance",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "MinaBalance",
                table: "Accounts");
        }
    }
}
