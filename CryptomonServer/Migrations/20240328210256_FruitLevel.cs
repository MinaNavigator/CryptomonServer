using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptomonServer.Migrations
{
    /// <inheritdoc />
    public partial class FruitLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelMin",
                table: "Fruits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 1,
                column: "LevelMin",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 2,
                column: "LevelMin",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 3,
                column: "LevelMin",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 4,
                column: "LevelMin",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 5,
                column: "LevelMin",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 6,
                column: "LevelMin",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 7,
                column: "LevelMin",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelMin",
                table: "Fruits");
        }
    }
}
