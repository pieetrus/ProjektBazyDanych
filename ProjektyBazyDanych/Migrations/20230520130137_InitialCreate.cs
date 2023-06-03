using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektyBazyDanych.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rodzaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statusy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statusy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projekty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kwota = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RodzajId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projekty_Rodzaje_RodzajId",
                        column: x => x.RodzajId,
                        principalTable: "Rodzaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projekty_Statusy_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statusy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_RodzajId",
                table: "Projekty",
                column: "RodzajId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_StatusId",
                table: "Projekty",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projekty");

            migrationBuilder.DropTable(
                name: "Rodzaje");

            migrationBuilder.DropTable(
                name: "Statusy");
        }
    }
}
