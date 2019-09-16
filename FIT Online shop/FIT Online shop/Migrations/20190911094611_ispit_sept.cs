using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Online_shop.Migrations
{
    public partial class ispit_sept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slikaUrl",
                table: "Proizvod",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpcijaModel",
                table: "NarudzbaStavka",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Sirina",
                table: "NarudzbaStavka",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "StranaOtvora",
                table: "NarudzbaStavka",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Visina",
                table: "NarudzbaStavka",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "ProizvodOpcije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodOpcije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProizvodOpcije_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodOpcije_ProizvodId",
                table: "ProizvodOpcije",
                column: "ProizvodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProizvodOpcije");

            migrationBuilder.DropColumn(
                name: "slikaUrl",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "OpcijaModel",
                table: "NarudzbaStavka");

            migrationBuilder.DropColumn(
                name: "Sirina",
                table: "NarudzbaStavka");

            migrationBuilder.DropColumn(
                name: "StranaOtvora",
                table: "NarudzbaStavka");

            migrationBuilder.DropColumn(
                name: "Visina",
                table: "NarudzbaStavka");
        }
    }
}
