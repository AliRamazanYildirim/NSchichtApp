using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSchicht.Quelle.Migrations
{
    public partial class Initale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ErstellungsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeuesDatum = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produkte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vorrat = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KategorieID = table.Column<int>(type: "int", nullable: false),
                    ErstellungsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeuesDatum = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkte", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produkte_Kategorien_KategorieID",
                        column: x => x.KategorieID,
                        principalTable: "Kategorien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduktEigenschaften",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farbe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Höhe = table.Column<int>(type: "int", nullable: false),
                    Breite = table.Column<int>(type: "int", nullable: false),
                    ProduktID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktEigenschaften", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProduktEigenschaften_Produkte_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorien",
                columns: new[] { "ID", "ErstellungsDatum", "Name", "NeuesDatum" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bleistifte", null });

            migrationBuilder.InsertData(
                table: "Kategorien",
                columns: new[] { "ID", "ErstellungsDatum", "Name", "NeuesDatum" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bücher", null });

            migrationBuilder.InsertData(
                table: "Kategorien",
                columns: new[] { "ID", "ErstellungsDatum", "Name", "NeuesDatum" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notizbücher", null });

            migrationBuilder.InsertData(
                table: "Produkte",
                columns: new[] { "ID", "ErstellungsDatum", "KategorieID", "Name", "NeuesDatum", "Preis", "Vorrat" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8276), 1, "Aspekte Neu B2+", null, 100m, 100 },
                    { 2, new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8300), 1, "Aspekte Neu C1", null, 110m, 100 },
                    { 3, new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8306), 1, "Aspekte Neu C2", null, 135m, 100 },
                    { 4, new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8311), 2, "Rotring 800+ 0.7mm", null, 85m, 100 },
                    { 5, new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8316), 2, "Rotring 600 0.5mm", null, 55m, 100 }
                });

            migrationBuilder.InsertData(
                table: "ProduktEigenschaften",
                columns: new[] { "ID", "Breite", "Farbe", "Höhe", "ProduktID" },
                values: new object[] { 1, 21, "Schwarz", 30, 1 });

            migrationBuilder.InsertData(
                table: "ProduktEigenschaften",
                columns: new[] { "ID", "Breite", "Farbe", "Höhe", "ProduktID" },
                values: new object[] { 2, 21, "Grün", 30, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_KategorieID",
                table: "Produkte",
                column: "KategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktEigenschaften_ProduktID",
                table: "ProduktEigenschaften",
                column: "ProduktID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktEigenschaften");

            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropTable(
                name: "Kategorien");
        }
    }
}
