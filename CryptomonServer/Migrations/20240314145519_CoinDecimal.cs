using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptomonServer.Migrations
{
    /// <inheritdoc />
    public partial class CoinDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MinaBalance",
                table: "Accounts",
                type: "numeric(32,9)",
                precision: 32,
                scale: 9,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoinBalance",
                table: "Accounts",
                type: "numeric(32,9)",
                precision: 32,
                scale: 9,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "MinaBalance",
                table: "Accounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(32,9)",
                oldPrecision: 32,
                oldScale: 9);

            migrationBuilder.AlterColumn<long>(
                name: "CoinBalance",
                table: "Accounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(32,9)",
                oldPrecision: 32,
                oldScale: 9);
        }
    }
}
