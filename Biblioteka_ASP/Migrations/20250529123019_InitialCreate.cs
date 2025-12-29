using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka_ASP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gatunki",
                columns: table => new
                {
                    ID_Gatunku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gatunek = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunki", x => x.ID_Gatunku);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    ID_Klienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.ID_Klienta);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    ID_Ksiazki = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rok_Wydania = table.Column<int>(type: "int", nullable: false),
                    ID_Gatunku = table.Column<int>(type: "int", nullable: false),
                    Ilosc_Dostepna = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.ID_Ksiazki);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Gatunki_ID_Gatunku",
                        column: x => x.ID_Gatunku,
                        principalTable: "Gatunki",
                        principalColumn: "ID_Gatunku",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenia",
                columns: table => new
                {
                    ID_Wypozyczenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Ksiazki = table.Column<int>(type: "int", nullable: false),
                    ID_Klienta = table.Column<int>(type: "int", nullable: false),
                    Data_Wypozyczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Zwrotu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenia", x => x.ID_Wypozyczenia);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Klienci_ID_Klienta",
                        column: x => x.ID_Klienta,
                        principalTable: "Klienci",
                        principalColumn: "ID_Klienta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Ksiazki_ID_Ksiazki",
                        column: x => x.ID_Ksiazki,
                        principalTable: "Ksiazki",
                        principalColumn: "ID_Ksiazki",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_ID_Gatunku",
                table: "Ksiazki",
                column: "ID_Gatunku");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_ID_Klienta",
                table: "Wypozyczenia",
                column: "ID_Klienta");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_ID_Ksiazki",
                table: "Wypozyczenia",
                column: "ID_Ksiazki");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wypozyczenia");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Gatunki");
        }
    }
}
