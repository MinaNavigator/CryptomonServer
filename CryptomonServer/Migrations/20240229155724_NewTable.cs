using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptomonServer.Migrations
{
    /// <inheritdoc />
    public partial class NewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Monsters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Monsters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "GameActions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "GameActions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_AccountId",
                table: "Monsters",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Accounts_AccountId",
                table: "Monsters",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Accounts_AccountId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_AccountId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "GameActions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "GameActions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
