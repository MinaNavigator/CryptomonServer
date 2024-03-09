using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CryptomonServer.Migrations
{
    /// <inheritdoc />
    public partial class Farm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fruits",
                columns: table => new
                {
                    FruitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GrowTime = table.Column<int>(type: "integer", nullable: false),
                    SeedPrice = table.Column<long>(type: "bigint", nullable: false),
                    PlantPrice = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fruits", x => x.FruitId);
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    LandId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.LandId);
                    table.ForeignKey(
                        name: "FK_Lands_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plantings",
                columns: table => new
                {
                    PlantingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LandId = table.Column<int>(type: "integer", nullable: false),
                    Square = table.Column<int>(type: "integer", nullable: false),
                    FruitId = table.Column<int>(type: "integer", nullable: false),
                    PlantingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantings", x => x.PlantingId);
                    table.ForeignKey(
                        name: "FK_Plantings_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lands_AccountId",
                table: "Lands",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantings_LandId_Square",
                table: "Plantings",
                columns: new[] { "LandId", "Square" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fruits");

            migrationBuilder.DropTable(
                name: "Plantings");

            migrationBuilder.DropTable(
                name: "Lands");
        }
    }
}
