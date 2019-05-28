using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Online_shop.Migrations
{
    public partial class Dostava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumNarudzbe = table.Column<DateTime>(nullable: false),
                    Cijena = table.Column<float>(nullable: false),
                    DostavaIme = table.Column<string>(nullable: true),
                    DostavaTelefon = table.Column<string>(nullable: true),
                    DostavaPostanskiBroj = table.Column<string>(nullable: true),
                    DostavaAdresa = table.Column<string>(nullable: true),
                    DostavaOpstina = table.Column<int>(nullable: false),
                    DostavaOpstinaIDId = table.Column<int>(nullable: true),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Opstina_DostavaOpstinaIDId",
                        column: x => x.DostavaOpstinaIDId,
                        principalTable: "Opstina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NarudzbaID = table.Column<int>(nullable: false),
                    ProizvodID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Narudzba_NarudzbaID",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_DostavaOpstinaIDId",
                table: "Narudzba",
                column: "DostavaOpstinaIDId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_NarudzbaID",
                table: "NarudzbaStavka",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_ProizvodID",
                table: "NarudzbaStavka",
                column: "ProizvodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NarudzbaStavka");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Opstina");
        }
    }
}
