using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CryptomonServer.Migrations
{
    /// <inheritdoc />
    public partial class FruitList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fruits",
                columns: new[] { "FruitId", "GrowTime", "Name", "PlantPrice", "SeedPrice" },
                values: new object[,]
                {
                    { 1, 120, "Wheat", 0.04m, 0.02m },
                    { 2, 300, "Potato", 0.16m, 0.10m },
                    { 3, 3600, "Pumpkin", 0.80m, 0.40m },
                    { 4, 14400, "Beetroot", 1.8m, 1m },
                    { 5, 28800, "Cauliflower", 8m, 4m },
                    { 6, 86400, "Parsnip", 16m, 10m },
                    { 7, 259200, "Radish", 80m, 50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fruits",
                keyColumn: "FruitId",
                keyValue: 7);
        }
    }
}
