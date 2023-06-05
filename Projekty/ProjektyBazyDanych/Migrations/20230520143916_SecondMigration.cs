using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektyBazyDanych.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Rodzaje",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Rodzaje_Nazwa",
                table: "Rodzaje",
                column: "Nazwa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rodzaje_Nazwa",
                table: "Rodzaje");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Rodzaje",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
