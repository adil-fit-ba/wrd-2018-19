using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelFirma20220924",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelFirma20220924", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DestinacijaVM20220924",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MjestoDrzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CijenaDolar = table.Column<double>(type: "float", nullable: false),
                    OpisPonude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelFirmaID = table.Column<int>(type: "int", nullable: false),
                    AkcijaPoruka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinacijaVM20220924", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DestinacijaVM20220924_TravelFirma20220924_TravelFirmaID",
                        column: x => x.TravelFirmaID,
                        principalTable: "TravelFirma20220924",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinacijaVM20220924_TravelFirmaID",
                table: "DestinacijaVM20220924",
                column: "TravelFirmaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinacijaVM20220924");

            migrationBuilder.DropTable(
                name: "TravelFirma20220924");
        }
    }
}
