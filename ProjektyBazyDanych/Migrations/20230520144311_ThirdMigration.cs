using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektyBazyDanych.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rodzaje_Nazwa",
                table: "Rodzaje");

            migrationBuilder.CreateIndex(
                name: "IX_Rodzaje_Nazwa",
                table: "Rodzaje",
                column: "Nazwa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rodzaje_Nazwa",
                table: "Rodzaje");

            migrationBuilder.CreateIndex(
                name: "IX_Rodzaje_Nazwa",
                table: "Rodzaje",
                column: "Nazwa");
        }
    }
}
