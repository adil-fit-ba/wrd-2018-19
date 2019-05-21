using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.Migrations
{
    public partial class incijalno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opstinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    BrojIndeksa = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: true),
                    DatumUpisa = table.Column<DateTime>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    OpstinaRodjenjaId = table.Column<int>(nullable: true),
                    OpstinaPrebivalistaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Opstinas_OpstinaPrebivalistaId",
                        column: x => x.OpstinaPrebivalistaId,
                        principalTable: "Opstinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Opstinas_OpstinaRodjenjaId",
                        column: x => x.OpstinaRodjenjaId,
                        principalTable: "Opstinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_OpstinaPrebivalistaId",
                table: "Students",
                column: "OpstinaPrebivalistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_OpstinaRodjenjaId",
                table: "Students",
                column: "OpstinaRodjenjaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Opstinas");
        }
    }
}
