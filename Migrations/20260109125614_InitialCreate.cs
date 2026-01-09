using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionInscriptions.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnneeScolaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Statut = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeScolaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Montant = table.Column<decimal>(type: "TEXT", nullable: false),
                    EtudiantId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnneeScolaireId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscriptions_AnneeScolaires_AnneeScolaireId",
                        column: x => x.AnneeScolaireId,
                        principalTable: "AnneeScolaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AnneeScolaires",
                columns: new[] { "Id", "Code", "Libelle", "Statut" },
                values: new object[,]
                {
                    { 1, "2024-2025", "Année 2024-2025", 0 },
                    { 2, "2023-2024", "Année 2023-2024", 1 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Code", "Libelle" },
                values: new object[,]
                {
                    { 1, "L1", "Licence 1" },
                    { 2, "L2", "Licence 2" },
                    { 3, "L3", "Licence 3" }
                });

            migrationBuilder.InsertData(
                table: "Etudiants",
                columns: new[] { "Id", "Matricule", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, "ETU001", "Diallo", "Mamadou" },
                    { 2, "ETU002", "Traoré", "Fatou" },
                    { 3, "ETU003", "Sow", "Aminata" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_AnneeScolaireId",
                table: "Inscriptions",
                column: "AnneeScolaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_ClasseId",
                table: "Inscriptions",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_EtudiantId",
                table: "Inscriptions",
                column: "EtudiantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "AnneeScolaires");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Etudiants");
        }
    }
}
