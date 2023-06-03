using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektyBazyDanych.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Statusy",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Statusy_Nazwa",
                table: "Statusy",
                column: "Nazwa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Statusy_Nazwa",
                table: "Statusy");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Statusy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
