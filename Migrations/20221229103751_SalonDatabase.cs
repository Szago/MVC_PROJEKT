using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektMVC.Migrations
{
    /// <inheritdoc />
    public partial class SklepDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    ProduktID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.ProduktID);
                });

            migrationBuilder.CreateTable(
                name: "CreateProduktViewModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false)

                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CreateSklepListViewModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),

                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CreatePracownicyViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Imie = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NrTel = table.Column<int>(type: "INTEGER", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EditProduktViewModel",
                columns: table => new
                {
                    ProduktID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false)

                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EditSklepModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),

                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EditPracownicyModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Imie = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NrTel = table.Column<int>(type: "INTEGER", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sklepy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklepy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PracownicyLista",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    NrTel = table.Column<int>(type: "INTEGER", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracownicyLista", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "CreateProduktViewModel");

            migrationBuilder.DropTable(
                name: "CreateSklepListViewModel");

            migrationBuilder.DropTable(
                name: "CreatePracownicyViewModel");

            migrationBuilder.DropTable(
                name: "EditProduktViewModel");

            migrationBuilder.DropTable(
                name: "EditSklepModel");

            migrationBuilder.DropTable(
                name: "EditPracownicyModel");

            migrationBuilder.DropTable(
                name: "Sklepy");

            migrationBuilder.DropTable(
                name: "PracownicyLista");
        }
    }
}
